using System;
using System.Collections.Generic;
using System.Text;
using Musei.Module;
using DevExpress.Xpo;

namespace WinTicketNext.CostruzionePercorso
{
    public class OptimizationFactory
    {
        public OptimizationFactory(
            GestoreProfili gestoreProfili, 
            UnitOfWork uow)
        {
            m_GestoreProfili = gestoreProfili;
            m_UnitOfWork = uow;
        }

        private GestoreProfili m_GestoreProfili;
        private GestoreProfili m_GestoreProfiloUnico;
        private UnitOfWork m_UnitOfWork;

        public void CalcolaSoluzioneKernel(List<Ingresso> dafare)
        {
            // tutte le varianti per i SINGOLI
            XPCollection<Variante> varianti = new XPCollection<Variante>(m_UnitOfWork);
            //varianti.Criteria = new BinaryOperator("TipologiaTre", TipologiaTreEnum.Standard, BinaryOperatorType.Equal);
            varianti.Sorting = new SortingCollection(varianti, 
                new SortProperty[] { new SortProperty("Biglietto.Percorso.Ingressi.Count", DevExpress.Xpo.DB.SortingDirection.Descending) });

            m_TutteLeVarianti = new List<Variante>();
            foreach (Variante item in varianti)
            {
                if (item.Biglietto.ComprendeData(DateTime.Now) && item.ComprendeData(DateTime.Now) &&
                    item.PrezzoAttuale != null && item.VenditaAbilitata)
                {
                    if (item.TipologiaTre == EnumTipologiaTre.CardMyFE && !item.MyFeComune())
                        continue;

                    m_TutteLeVarianti.Add(item);
                }
            }

            CercaIlPercorsoMigliore(m_GestoreProfili, dafare);

            // VERIFICA SE CONVIENE IL GRUPPO
            // verifica con un profilo unico, senza titoli per riduzione
            m_GestoreProfiloUnico = new GestoreProfili(m_GestoreProfili.TipologiaMyFe);
            ProfiloCliente nuovoProfilo = new ProfiloCliente();
            nuovoProfilo.ElencoTitoli = new List<Titolo>();
            nuovoProfilo.NumeroPersone = m_GestoreProfili.TotalePersone();
            nuovoProfilo.Scuola = false;
            nuovoProfilo.OttimizzaCalcolo = true;

            m_GestoreProfiloUnico.ElencoProfili.Add(nuovoProfilo);
            List<Ingresso> nuovoDafare = new List<Ingresso>(dafare);
            CercaIlPercorsoMigliore(m_GestoreProfiloUnico, nuovoDafare);
        }

        public GestoreProfili GestoreProfiloUnico
        {
            get
            {
                return m_GestoreProfiloUnico;
            }
        }

        private void CercaIlPercorsoMigliore(GestoreProfili gestore, List<Ingresso> dafare)
        {
            // cerca il percorso migliore
            List<SoluzioneIngressiItem> nuovoPercorso = new List<SoluzioneIngressiItem>();
            
            foreach (ProfiloCliente item in gestore.ElencoProfili)
            {
                item.ElencoSoluzioni.CancellaContenuto();

                Tentativo(item, nuovoPercorso, 0, -1, dafare);

                item.TrovaSoluzionePreferita();
            }
        }

        public List<Suggerimento> Suggerimenti(List<Ingresso> dafare)
        {
            List<Suggerimento> suggerimenti = new List<Suggerimento>();

            if (dafare.Count == 0 || m_GestoreProfili.ElencoProfili.Count == 0)
                return suggerimenti;

            if (dafare.Count >= 5)
                return suggerimenti;

            // assumo di avere una soluzione valida
            decimal gestoreProfiliTotaleImporto = m_GestoreProfili.TotaleImporto();
            decimal sogliaMax = gestoreProfiliTotaleImporto * 1.20m;
            decimal sogliaMin = gestoreProfiliTotaleImporto * 0.7m;

            if (gestoreProfiliTotaleImporto == 0)
                return suggerimenti;

            // clona m_GestoreProfili
            GestoreProfili nuovoGestore = new GestoreProfili(m_GestoreProfili.TipologiaMyFe);
            foreach (ProfiloCliente item in m_GestoreProfili.ElencoProfili)
            {
                ProfiloCliente nuovoProfilo = new ProfiloCliente();
                nuovoProfilo.ElencoTitoli = item.ElencoTitoli;
                nuovoProfilo.NumeroPersone = item.NumeroPersone;
                nuovoProfilo.Scuola = item.Scuola;
                nuovoProfilo.OttimizzaCalcolo = true;

                nuovoGestore.ElencoProfili.Add(nuovoProfilo);
            }

            // calcola suggerimenti
            XPCollection<Ingresso> ingressi = new XPCollection<Ingresso>(m_UnitOfWork);
            for (int indicePrimo = 0; indicePrimo < ingressi.Count; indicePrimo++)
            {
                Ingresso ingressoPrimo = ingressi[indicePrimo];

                if (ingressoPrimo.Tipologia != EnumTipologiaIngresso.Museo)
                    continue;
                
                if (!dafare.Contains(ingressoPrimo))
                {
                    List<Ingresso> nuovoDafare = new List<Ingresso>(dafare);
                    nuovoDafare.Add(ingressoPrimo);

                    CercaIlPercorsoMigliore(nuovoGestore, nuovoDafare);

                    decimal nuovoGestoreTotaleImporto = nuovoGestore.TotaleImporto();
                    if (nuovoGestoreTotaleImporto <= sogliaMax && nuovoGestoreTotaleImporto > sogliaMin)
                    {
                        Suggerimento sugg = new Suggerimento();
                        sugg.Importo = nuovoGestoreTotaleImporto - gestoreProfiliTotaleImporto;
                        sugg.DescrizioneUno = ingressoPrimo.Descrizione;
                        sugg.DescrizioneDue = string.Empty;
                        sugg.IngressoUno = ingressoPrimo;
                        sugg.IngressoDue = null;

                        suggerimenti.Add(sugg);
                    }

                    if (nuovoDafare.Count <= 3)
                    {
                        // provo ad aggiungerne un altro
                        for (int indiceSecondo = indicePrimo + 1; indiceSecondo < ingressi.Count; indiceSecondo++)
                        {
                            Ingresso ingressoSecondo = ingressi[indiceSecondo];

                            if (ingressoSecondo.Tipologia != EnumTipologiaIngresso.Museo)
                                continue;
                
                            if (!dafare.Contains(ingressoSecondo))
                            {
                                List<Ingresso> nuovoDafareSecondo = new List<Ingresso>(nuovoDafare);
                                nuovoDafareSecondo.Add(ingressoSecondo);

                                // aggiungo due ingressi

                                CercaIlPercorsoMigliore(nuovoGestore, nuovoDafareSecondo);

                                nuovoGestoreTotaleImporto = nuovoGestore.TotaleImporto();
                                if (nuovoGestoreTotaleImporto <= sogliaMax && nuovoGestoreTotaleImporto > sogliaMin)
                                {
                                    Suggerimento sugg = new Suggerimento();
                                    sugg.Importo = nuovoGestoreTotaleImporto - gestoreProfiliTotaleImporto;
                                    sugg.DescrizioneUno = ingressoPrimo.Descrizione;
                                    sugg.DescrizioneDue = ingressoSecondo.Descrizione;
                                    sugg.IngressoUno = ingressoPrimo;
                                    sugg.IngressoDue = ingressoSecondo;

                                    suggerimenti.Add(sugg);
                                }
                            }
                        }
                    }
                }                
            }

            return suggerimenti;
        }

        private List<Variante> m_TutteLeVarianti;
        private void Tentativo(ProfiloCliente cliente, List<SoluzioneIngressiItem> elencoPercorso, decimal importoPercorso, int indice, List<Ingresso> dafare)
        {
            if (dafare.Count == 0)
            {
                // valida soluzione per bigliettone
                if (SoluzioneValidaPerBigliettone(elencoPercorso))
                {
                    decimal importoTotale = 0;
                    decimal importoUnitario = 0;

                    // ho trovato una soluzione
                    foreach (SoluzioneIngressiItem item in elencoPercorso)
                    {
                        importoTotale += item.PrezzoTotale;
                        importoUnitario += item.PrezzoUnitario;
                    }

                    List<Ingresso> visitati = new List<Ingresso>();
                    foreach (SoluzioneIngressiItem variante1 in elencoPercorso)
                        foreach (Ingresso item in variante1.Variante.Biglietto.Percorso.Ingressi)
                            if (!visitati.Contains(item))
                                visitati.Add(item);

                    SoluzioneIngressi sol = new SoluzioneIngressi();

                    sol.Elenco = new List<SoluzioneIngressiItem>();
                    sol.Elenco.AddRange(elencoPercorso);

                    sol.NumeroIngressi = visitati.Count;
                    sol.NumeroPercorsi = elencoPercorso.Count;
                    sol.ImportoTotale = importoTotale;
                    sol.ImportoUnitario = importoUnitario;
                    sol.NumeroPersone = cliente.NumeroPersone;

                    cliente.ElencoSoluzioni.AggiungiSoluzioneSeNonDuplicata(sol);
                }
            }
            else
            {
                if (cliente.OttimizzaCalcolo && cliente.ElencoSoluzioni.SogliaImporto >= 0)
                {
                    // inutile proseguire ulteriormente
                    if (importoPercorso > cliente.ElencoSoluzioni.SogliaImporto)
                        return;
                }

                for (int newIndice = indice + 1; newIndice < m_TutteLeVarianti.Count; newIndice++)
                {
                    Titolo titolo = null;
                    Variante variante = m_TutteLeVarianti[newIndice];

                    if (variante.TipologiaTre == EnumTipologiaTre.CardMyFE)
                    {
                        // CARD MY-FE con prezzo sdoppiato -C]
                        if (variante.ComprendeAlmenoUno(dafare) && variante.GiorniCardMyFe() == m_GestoreProfili.TipologiaMyFe && variante.Note.Contains("-C]"))
                        {
                            List<Ingresso> davisitare = new List<Ingresso>(dafare);
                            foreach (Ingresso ingresso in variante.Biglietto.Percorso.Ingressi)
                                davisitare.Remove(ingresso);

                            decimal prezzo = 0;
                            SoluzioneIngressiItem tentativo = null;
                            SoluzioneIngressiItem tentativoSecondario = null;

                            tentativo = new SoluzioneIngressiItem(variante, null, cliente.NumeroPersone);
                            prezzo = tentativo.PrezzoTotale;

                            tentativoSecondario = new SoluzioneIngressiItem(variante.PrezzoAttuale.PrezzoRidotto, null, cliente.NumeroPersone);
                            prezzo += tentativoSecondario.PrezzoTotale;

                            elencoPercorso.Add(tentativo);
                            elencoPercorso.Add(tentativoSecondario);

                            Tentativo(cliente, elencoPercorso, importoPercorso + prezzo, newIndice, davisitare);

                            elencoPercorso.Remove(tentativoSecondario);
                            elencoPercorso.Remove(tentativo);
                        }

                        // campo note che finisce con -B è solo COMUNE
                        if (variante.ComprendeAlmenoUno(dafare) && variante.GiorniCardMyFe() == m_GestoreProfili.TipologiaMyFe && variante.Note.Contains("-B]"))
                        {
                            List<Ingresso> davisitare = new List<Ingresso>(dafare);
                            foreach (Ingresso ingresso in variante.Biglietto.Percorso.Ingressi)
                                davisitare.Remove(ingresso);

                            decimal prezzo = 0;
                            SoluzioneIngressiItem tentativo = null;
                            //SoluzioneIngressiItem tentativoSecondario = null;

                            tentativo = new SoluzioneIngressiItem(variante, null, cliente.NumeroPersone);
                            prezzo = tentativo.PrezzoTotale;

                            //tentativoSecondario = new SoluzioneIngressiItem(variante.PrezzoAttuale.PrezzoRidotto, null, cliente.NumeroPersone);
                            //prezzo += tentativoSecondario.PrezzoTotale;

                            elencoPercorso.Add(tentativo);
                            //elencoPercorso.Add(tentativoSecondario);

                            Tentativo(cliente, elencoPercorso, importoPercorso + prezzo, newIndice, davisitare);

                            //elencoPercorso.Remove(tentativoSecondario);
                            elencoPercorso.Remove(tentativo);
                        }
                    }
                    else
                    {
                        if (variante.HoTitoloPerComprarlo(cliente.ElencoTitoli, cliente.ElencoCodiciSconto, cliente.NumeroPersone, cliente.Scuola, out titolo))
                        {
                            if (variante.ComprendeAlmenoUno(dafare))
                            {
                                List<Ingresso> davisitare = new List<Ingresso>(dafare);
                                foreach (Ingresso ingresso in variante.Biglietto.Percorso.Ingressi)
                                    davisitare.Remove(ingresso);

                                decimal prezzo = 0;
                                SoluzioneIngressiItem tentativo = null;
                                SoluzioneIngressiItem tentativoSecondario = null;
                                if (titolo != null && titolo.TitoloPrincipale != null && titolo.TitoloSecondario != null)
                                {
                                    // GESTIONE TITOLI SECONDARI (solo il primo e' titolare, gli altri accompagnatori)
                                    tentativo = new SoluzioneIngressiItem(variante, titolo.TitoloPrincipale, 1);
                                    prezzo = tentativo.PrezzoTotale;

                                    if (cliente.NumeroPersone > 1)
                                    {
                                        tentativoSecondario = new SoluzioneIngressiItem(variante, titolo.TitoloSecondario, cliente.NumeroPersone - 1);
                                        prezzo += tentativoSecondario.PrezzoTotale;
                                    }
                                }
                                else
                                {
                                    if (variante.PrezzoAttuale.UnaRiduzioneOgni > 0 && variante.PrezzoAttuale.PrezzoRidotto != null)
                                    {
                                        int numRidotti = cliente.NumeroPersone / variante.PrezzoAttuale.UnaRiduzioneOgni;
                                        int numInteri = cliente.NumeroPersone - numRidotti;

                                        tentativo = new SoluzioneIngressiItem(variante, titolo, numInteri);
                                        prezzo = tentativo.PrezzoTotale;

                                        if (numRidotti > 0)
                                        {
                                            tentativoSecondario = new SoluzioneIngressiItem(variante.PrezzoAttuale.PrezzoRidotto, titolo, numRidotti);
                                            prezzo += tentativoSecondario.PrezzoTotale;
                                        }
                                    }
                                    else
                                    {
                                        tentativo = new SoluzioneIngressiItem(variante, titolo, cliente.NumeroPersone);
                                        prezzo = tentativo.PrezzoTotale;
                                    }
                                }

                                elencoPercorso.Add(tentativo);
                                if (tentativoSecondario != null)
                                {
                                    elencoPercorso.Add(tentativoSecondario);
                                    foreach (Ingresso ingresso in tentativoSecondario.Variante.Biglietto.Percorso.Ingressi)
                                        davisitare.Remove(ingresso);
                                }

                                Tentativo(cliente, elencoPercorso, importoPercorso + prezzo, newIndice, davisitare);

                                if (tentativoSecondario != null) elencoPercorso.Remove(tentativoSecondario);
                                elencoPercorso.Remove(tentativo);
                            }
                        }
                    }
                }
            }
        }

        private static bool SoluzioneValidaPerBigliettone(List<SoluzioneIngressiItem> elencoPercorso)
        {
            int bigliettoni = 0;
            foreach (SoluzioneIngressiItem soluzioneIngressiItem in elencoPercorso)
            {
                if (soluzioneIngressiItem.Variante.TipologiaTre == EnumTipologiaTre.Bigliettone)
                {
                    // deve avere un costo diverso da zero
                    if (soluzioneIngressiItem.Variante.Prezzo > 0)
                        bigliettoni++;
                }
            }

            // la soluzione deve avere almeno 3 (oppure 0) varianti bigliettone per essere valida

            if (bigliettoni == 1 || bigliettoni == 2)
                return false;
            else
                return true;
        }


    }
}

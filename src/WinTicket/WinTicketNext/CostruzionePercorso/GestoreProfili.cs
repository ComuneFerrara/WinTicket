using System;
using System.Collections.Generic;
using System.ComponentModel;
using Musei.Module;

namespace WinTicketNext.CostruzionePercorso
{
    public class GestoreProfili
    {
        public BindingList<ProfiloCliente> ElencoProfili { get; set; }
        public List<CodiceSconto> ElencoCodiciSconto { get; set; }

        public EnumTipologiaCard TipologiaMyFe { get; set; }

        public void SetCodiceSconto(CodiceSconto sconto)
        {
            ElencoCodiciSconto.Clear();
            foreach (ProfiloCliente profiloCliente in ElencoProfili)
            	profiloCliente.ElencoCodiciSconto.Clear();

            if (sconto != null)
            {
                ElencoCodiciSconto.Add(sconto);
                foreach (ProfiloCliente profiloCliente in ElencoProfili)
            	    profiloCliente.ElencoCodiciSconto.Add(sconto);
            }
        }

        public CodiceSconto GetCodiceSconto()
        {
            if (ElencoCodiciSconto.Count > 0) return ElencoCodiciSconto[0];
            return null;
        }

        public int TotalePersone()
        {
            int totale = 0;
            foreach (ProfiloCliente profiloCliente in ElencoProfili)
            {
                totale += profiloCliente.NumeroPersone;
                
            }
            return totale; 
        }

        public int TotalePersoneScuole()
        {
            int totale = 0;
            foreach (ProfiloCliente profiloCliente in ElencoProfili)
            {
                if (profiloCliente.Scuola)
                    totale += profiloCliente.NumeroPersone;

            }
            return totale;
        }

        public GestoreProfili(EnumTipologiaCard myfe)
        {
            ElencoProfili = new BindingList<ProfiloCliente>();
            ElencoCodiciSconto = new List<CodiceSconto>();
            TipologiaMyFe = myfe;
        }

        public decimal TotaleImporto()
        {
            decimal totale = 0;
            foreach (ProfiloCliente profiloCliente in ElencoProfili)
            {
                SoluzioneIngressi soluzione = profiloCliente.SoluzionePreferita;
                if (soluzione != null)
                    totale += soluzione.ImportoTotale;
            }
            return totale;
        }

        public decimal TotaleImportoNoBigliettone()
        {
            decimal totale = 0;
            foreach (ProfiloCliente profiloCliente in ElencoProfili)
            {
                SoluzioneIngressi soluzione = profiloCliente.SoluzionePreferitaNoBigliettone;
                if (soluzione != null)
                    totale += soluzione.ImportoTotale;
            }
            return totale;
        }

        public bool Bigliettone()
        {
            foreach (ProfiloCliente profiloCliente in ElencoProfili)
                if (profiloCliente.SoluzionePreferita.Bigliettone())
                    return true;

            return false;
        }

        internal bool SoluzioneTrovata()
        {
            foreach (ProfiloCliente profilo in ElencoProfili)
            {
                if (profilo.SoluzionePreferita == null)
                {
                    return false;
                }
            }

            return true;
        }

        internal bool CardMusei()
        {
            foreach (ProfiloCliente profiloCliente in ElencoProfili)
                if (profiloCliente.SoluzionePreferita.CardMusei())
                    return true;

            return false;
        }

        internal bool Cumulativo()
        {
            foreach (ProfiloCliente profiloCliente in ElencoProfili)
                if (profiloCliente.SoluzionePreferita.Cumulativo())
                    return true;

            return false;
        }

        internal bool RispettaRegole(EventoParticolare eventoParticolare)
        {
            if (eventoParticolare.Tipologia == EnumTipologiaEventoParticolare.MuseiComunaliOmaggio)
            {
                foreach (ProfiloCliente profiloCliente in ElencoProfili)
                {
                    if (IngressoComune(profiloCliente))
                    {
                        bool found = false;
                        foreach (Titolo item in profiloCliente.ElencoTitoli)
                        {
                            if (item.IsAttrib(EventoParticolare.STR_COM_EVT_OMAGGIO))
                                found = true;
                        }

                        if (!found)
                            return false;
                    }
                }
            }

            if (eventoParticolare.Tipologia == EnumTipologiaEventoParticolare.CastelloRidotto)
            {
                foreach (ProfiloCliente profiloCliente in ElencoProfili)
                {
                    if (IngressoProvincia(profiloCliente))
                    {
                        bool found = false;
                        foreach (Titolo item in profiloCliente.ElencoTitoli)
                        {
                            if (item.IsAttrib(EventoParticolare.STR_PROV_EVT_RIDOTTO))
                                found = true;
                        }

                        if (!found)
                            return false;
                    }
                }
            }

            if (eventoParticolare.Tipologia == EnumTipologiaEventoParticolare.NoIngressoTorre)
            {
                foreach (ProfiloCliente profiloCliente in ElencoProfili)
                {
                    if (IngressoTorre(profiloCliente))
                    {
                        return false;
                    }
                }
            }

            if (eventoParticolare.Tipologia == EnumTipologiaEventoParticolare.EscludiBiglietto && eventoParticolare.Biglietto != null)
            {
                foreach (ProfiloCliente profiloCliente in ElencoProfili)
                {
                    foreach (SoluzioneIngressiItem soluzioneIngressiItem in profiloCliente.SoluzionePreferita.Elenco)
                    {
                        if (soluzioneIngressiItem.Variante.Biglietto.Oid == eventoParticolare.Biglietto.Oid)
                            return false;
                    }
                }
            }

            if (eventoParticolare.Tipologia == EnumTipologiaEventoParticolare.TitoloRichiesto && eventoParticolare.Biglietto != null && eventoParticolare.Titolo != null)
            {
                foreach (ProfiloCliente profiloCliente in ElencoProfili)
                {
                    foreach (SoluzioneIngressiItem soluzioneIngressiItem in profiloCliente.SoluzionePreferita.Elenco)
                    {
                        if (soluzioneIngressiItem.Variante.Biglietto.Oid == eventoParticolare.Biglietto.Oid &&
                            (soluzioneIngressiItem.Titolo == null ||
                             soluzioneIngressiItem.Titolo.Oid != eventoParticolare.Titolo.Oid))
                            return false;
                    }
                }
            }

            return true;
        }


        private static bool IngressoTorre(ProfiloCliente profiloCliente)
        {
            bool ingressotorre = false;
            foreach (SoluzioneIngressiItem soluzioneIngressiItem in profiloCliente.SoluzionePreferita.Elenco)
            {
                foreach (var item in soluzioneIngressiItem.Variante.Biglietto.Percorso.Ingressi)
                {
                    if (item.IsAttrib(EventoParticolare.STR_INGRESSI_TORRE_FE))
                        ingressotorre = true;
                }
            }
            return ingressotorre;
        }

        private static bool IngressoComune(ProfiloCliente profiloCliente)
        {
            bool ingressocomune = false;
            foreach (SoluzioneIngressiItem soluzioneIngressiItem in profiloCliente.SoluzionePreferita.Elenco)
            {
                foreach (var item in soluzioneIngressiItem.Variante.Biglietto.Percorso.Ingressi)
                {
                    if (item.SoggettoEconomico.IsAttrib(EventoParticolare.STR_COMUNE_FE) && 
                        !item.IsAttrib(EventoParticolare.STR_NOFREE))
                        ingressocomune = true;
                }
            }
            return ingressocomune;
        }

        private static bool IngressoProvincia(ProfiloCliente profiloCliente)
        {
            bool ingressoprovincia = false;
            foreach (SoluzioneIngressiItem soluzioneIngressiItem in profiloCliente.SoluzionePreferita.Elenco)
            {
                foreach (var item in soluzioneIngressiItem.Variante.Biglietto.Percorso.Ingressi)
                {
                    if (item.SoggettoEconomico.IsAttrib(EventoParticolare.STR_PROVINCIA_FE))
                        ingressoprovincia = true;
                }
            }
            return ingressoprovincia;
        }

        public bool ConvieneCardMyFE()
        {
            foreach (var profilo in ElencoProfili)
            {
                if (profilo.SoluzionePreferita != null && !profilo.SoluzionePreferita.CardMyFE() && 
                    profilo.SoluzionePreferita.ImportoUnitario >= Card.PrezzoCard(EnumTipologiaCard.Card2Giorni)) 
                    return true;
            }
            return false;
        }

        public void ClearInfoCardMyFE()
        {
            foreach (var profilo in ElencoProfili)
            {
                foreach (SoluzioneIngressiItem soluzioneIngressiItem in profilo.SoluzionePreferita.Elenco)
                {
                    soluzioneIngressiItem.ElencoCardMyFE.Clear();
                }
            }            
        }

        internal int NumeroCardMyFE()
        {
            int count=0;
            foreach (var profilo in ElencoProfili)
            {
                foreach (SoluzioneIngressiItem soluzioneIngressiItem in profilo.SoluzionePreferita.Elenco)
                {
                    if (soluzioneIngressiItem.Variante.MyFeComune())
                        count += soluzioneIngressiItem.Quantita;
                }
            }
            return count;
        }
    }
}

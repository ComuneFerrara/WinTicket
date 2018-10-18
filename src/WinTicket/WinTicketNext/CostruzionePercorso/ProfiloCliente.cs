using System;
using System.Collections.Generic;
using System.Text;
using Musei.Module;

namespace WinTicketNext.CostruzionePercorso
{
    public class ProfiloCliente
    {
        public List<Titolo> ElencoTitoli { get; set; }
        public List<CodiceSconto> ElencoCodiciSconto { get; set; }

        public int NumeroPersone { get; set; }
        public bool Scuola { get; set; }
        public bool OttimizzaCalcolo { get; set; }
        public int CodiceProgressivo { get; set; }

        private ElencoSoluzioni m_ElencoSoluzioni;
        public ElencoSoluzioni ElencoSoluzioni
        {
            get { return m_ElencoSoluzioni; }
            set
            {
                m_ElencoSoluzioni = value;
                SoluzionePreferita = null;
            }
        }
        public SoluzioneIngressi SoluzionePreferita { get; set; }
        public SoluzioneIngressi SoluzionePreferitaNoBigliettone { get; set; }
        
        
        // solo per la visualizzazione
        public string Titoli
        {
            get 
            {
                string str = string.Empty;

                foreach (Titolo titolo in ElencoTitoli)
                {
                    if (str != string.Empty)
                        str += ", ";

                    str += titolo.Descrizione;
                }

                if (this.Scuola)
                    str = "[SCUOLA] " + str;

                if (ElencoCodiciSconto.Count > 0)
                    str = "{" + ElencoCodiciSconto[0].Descrizione + "} " + str;

                return str.Trim();
            }
        }

        // solo per la visualizzazione
        public string SoluzioneDescrizione
        {
            get
            {
                string str = string.Empty;
                if (SoluzionePreferita != null)
                {
                    //str += migliore.ImportoTotale.ToString("c") + " (" + migliore.ImportoUnitario.ToString("c") + " cad.)";

                    SoluzionePreferita.Elenco.Sort();

                    foreach (SoluzioneIngressiItem item in SoluzionePreferita.Elenco)
                    {
                        //if (item.Variante.TipologiaTre == EnumTipologiaTre.CardMyFE)
                        //{
                        //    //if (item.Variante.PrezzoAttuale.PrezzoRidotto != null)
                        //    //{
                        //        if (!string.IsNullOrEmpty(str))
                        //            str += Environment.NewLine;

                        //        str += String.Format("{0} {1:c}", item.Descrizione, item.PrezzoUnitario); // + item.Variante.PrezzoAttuale.PrezzoRidotto.Prezzo);
                        //    //}
                        //}
                        //else
                        //{

                            if (!string.IsNullOrEmpty(str))
                                str += Environment.NewLine;

                            str += String.Format("{0} {1:c}", item.Descrizione, item.PrezzoUnitario);

                        //}
                    }
                }
                else
                    return "NESSUNA SOLUZIONE";

                return str;
            }
        }

        // solo per la visualizzazione
        public decimal ImportoTotale
        {
            get
            {
                if (SoluzionePreferita != null)
                {
                    return SoluzionePreferita.ImportoTotale;
                }
                else
                    return 0;
            }
        }

        // solo per la visualizzazione
        public decimal ImportoUnitario
        {
            get
            {
                if (SoluzionePreferita != null)
                {
                    return SoluzionePreferita.ImportoUnitario;
                }
                else
                    return 0;
            }
        }

        public List<Ingresso> ElencoIngressiSoluzionePreferita()
        {
            List<Ingresso> elenco = new List<Ingresso>();
            if (SoluzionePreferita != null)
            {
                foreach (SoluzioneIngressiItem item in SoluzionePreferita.Elenco)
                {
                    foreach (Ingresso ingresso in item.Variante.Biglietto.Percorso.Ingressi)
                    {
                        if (!elenco.Contains(ingresso))
                            elenco.Add(ingresso);
                    }
                }
            }

            return elenco;
        }

        public ProfiloCliente()
        {
            m_ElencoSoluzioni = new ElencoSoluzioni();
            ElencoTitoli = new List<Titolo>();
            ElencoCodiciSconto = new List<CodiceSconto>();
            NumeroPersone = 1;
        }

        public ProfiloCliente(int numero, Titolo titolo, bool scuola)
        {
            m_ElencoSoluzioni = new ElencoSoluzioni();
            ElencoTitoli = new List<Titolo>();
            ElencoCodiciSconto = new List<CodiceSconto>();
            NumeroPersone = numero;
            Scuola = scuola;

            if (titolo != null) // && titolo.Tipologia == EnumTipologiaTitolo.Normale)
                ElencoTitoli.Add(titolo);
        }

        public void TrovaSoluzionePreferita()
        {
            SoluzionePreferita = m_ElencoSoluzioni.Economica();
            SoluzionePreferitaNoBigliettone = m_ElencoSoluzioni.EconomicaNoBigliettone();
        }

    }
}

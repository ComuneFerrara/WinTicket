using System;
using System.Collections.ObjectModel;

namespace WinTicketNext
{
    public class ElencoSoluzioni : Collection<SoluzioneIngressi>
    {
        public SoluzioneIngressi Economica()
        {
            SoluzioneIngressi migliore = null;
            foreach (SoluzioneIngressi item in this)
            {
                if (migliore == null)
                    migliore = item;
                else if (item.ImportoTotale < migliore.ImportoTotale)
                    migliore = item;
                else
                {
                    if (item.ImportoTotale == migliore.ImportoTotale)
                    {
                        if (item.NumeroPercorsi < migliore.NumeroPercorsi)
                            migliore = item;
                        else
                            if (item.NumeroPercorsi == migliore.NumeroPercorsi && item.NumeroDiGruppiOppureScuola() > migliore.NumeroDiGruppiOppureScuola())
                                migliore = item;
                    }
                }
            }

            return migliore;
        }

        public SoluzioneIngressi EconomicaNoBigliettone()
        {
            SoluzioneIngressi migliore = null;
            foreach (SoluzioneIngressi item in this)
            {
                if (item.Bigliettone())
                    continue;

                if (migliore == null)
                    migliore = item;
                else if (item.ImportoTotale < migliore.ImportoTotale)
                    migliore = item;
                else if (item.ImportoTotale == migliore.ImportoTotale && item.NumeroPercorsi < migliore.NumeroPercorsi)
                    migliore = item;
            }

            return migliore;
        }

        public decimal SogliaImporto { get; set; }

        public void CancellaContenuto()
        {
            this.Clear();
            SogliaImporto = -1;
        }

        public void AggiungiSoluzioneSeNonDuplicata(SoluzioneIngressi soluzione)
        {
            if (!EsisteDuplicato(soluzione))
            {
                if (SogliaImporto < 0 || soluzione.ImportoTotale < SogliaImporto)
                    SogliaImporto = soluzione.ImportoTotale;

                this.Add(soluzione);
            }
        }

        private bool EsisteDuplicato(SoluzioneIngressi soluzione)
        {
            foreach (SoluzioneIngressi item in this)
            {
                if (soluzione.Tipologia == item.Tipologia)
                {
                    // Controlla se TUTTE le VARIANTI di una soluzione sono presenti nell'altra
                    // e VICEVERSA
                    bool manca = false;

                    foreach (SoluzioneIngressiItem lista1 in item.Elenco)
                    {
                        bool found = false;
                        foreach (SoluzioneIngressiItem soluzioneIngressiItem in soluzione.Elenco)
                        {
                            if (lista1.Variante == soluzioneIngressiItem.Variante)
                            {
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            manca = true;
                            break;
                        }
                    }

                    if (!manca)
                    {
                        foreach (SoluzioneIngressiItem lista2 in soluzione.Elenco)
                        {
                            bool found = false;
                            foreach (SoluzioneIngressiItem soluzioneIngressiItem in item.Elenco)
                            {
                                if (lista2.Variante == soluzioneIngressiItem.Variante)
                                {
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                manca = true;
                                break;
                            }
                        }
                    }

                    if (!manca)
                        return true;
                }
            }

            return false;
        }

    }
}

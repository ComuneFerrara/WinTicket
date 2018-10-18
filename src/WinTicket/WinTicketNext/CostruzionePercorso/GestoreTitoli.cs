using System;
using System.Collections.Generic;
using Musei.Module;
using DevExpress.Xpo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace WinTicketNext.CostruzionePercorso
{
    public class GestoreTitoli
    {
        private UnitOfWork m_Uow;
        private List<Titolo> m_ElencoTitoli = new List<Titolo>();

        public GestoreTitoli(UnitOfWork uow)
        {
            m_Uow = uow;
        }

        public void ReBuildElencoTitoli(Percorso percorso, bool scuola, TreeList albero)
        {
            List<Titolo> elenco = new List<Titolo>();

            foreach (Biglietto biglietto in percorso.BigliettiValidi)
            {
                foreach (Variante variante in biglietto.Varianti)
                {
                    if (!variante.ComprendeData(DateTime.Now))
                        continue;

                    if (scuola)
                    {
                        if (variante.TipologiaUno != EnumTipologiaUno.Scuola)
                            continue;
                    }
                    else
                    {
                        if (variante.TipologiaUno != EnumTipologiaUno.Singolo &&
                            variante.TipologiaUno != EnumTipologiaUno.Gruppo
                            )
                            continue;
                    }

                    foreach (Titolo titolo in variante.ElencoTitoli)
                    {
                        if (!string.IsNullOrEmpty(titolo.Attributi) && titolo.Attributi.Contains("-UNIFE-")) continue;

                        if (!elenco.Contains(titolo))
                        {
                            elenco.Add(titolo);
                            titolo.Ridotto = titolo.Omaggio = string.Empty;
                        }

                        if (variante.TipologiaDue == EnumTipologiaDue.Omaggio)
                            titolo.Omaggio = "OMA";
                        if (variante.TipologiaDue == EnumTipologiaDue.Ridotto)
                            titolo.Ridotto = "RID";
                    }
                }
            }

            m_ElencoTitoli = elenco;

            BuildTreeTitoli(albero);
        }

        public void ReBuildElencoTitoli(IEnumerable<Ingresso> ingressi, bool scuola, TreeList albero)
        {
            List<Titolo> elenco = new List<Titolo>();
            List<Percorso> fatti = new List<Percorso>();

            foreach (Ingresso ingresso in ingressi)
            {
                foreach (Percorso percorso in ingresso.Percorsi)
                {
                    if (fatti.Contains(percorso)) continue;
                    fatti.Add(percorso);

                    foreach (Biglietto biglietto in percorso.BigliettiValidi)
                    {
                        foreach (Variante variante in biglietto.Varianti)
                        {
                            if (!variante.ComprendeData(DateTime.Now))
                                continue;
                            
                            if (scuola)
                            {
                                if (variante.TipologiaUno != EnumTipologiaUno.Scuola)
                                    continue;
                            }
                            else
                            {
                                if (variante.TipologiaUno != EnumTipologiaUno.Singolo &&
                                    variante.TipologiaUno != EnumTipologiaUno.Gruppo
                                    )
                                    continue;
                            }

                            foreach (Titolo titolo in variante.ElencoTitoli)
                            {
                                if (!string.IsNullOrEmpty(titolo.Attributi) && titolo.Attributi.Contains("-UNIFE-")) continue;

                                if (!elenco.Contains(titolo))
                                {
                                    elenco.Add(titolo);
                                    titolo.Ridotto = titolo.Omaggio = string.Empty;
                                }

                                if (variante.TipologiaDue == EnumTipologiaDue.Omaggio)
                                    titolo.Omaggio = "OMA";
                                if (variante.TipologiaDue == EnumTipologiaDue.Ridotto)
                                    titolo.Ridotto = "RID";
                            }
                        }
                    }
                }
            }

            m_ElencoTitoli = elenco;

            BuildTreeTitoli(albero);
        }

        public void ApplyElencoTitoli(List<Titolo> titoli, TreeList albero)
        {
            foreach (TreeListNode item in albero.Nodes)
            {
                if (!item.HasChildren)
                {
                    Titolo titolo = item.Tag as Titolo;
                    item.Checked = titoli.Contains(titolo);                    
                }
                else
                    ApplyElencoTitoli(titoli, item);
            }            
        }

        private void ApplyElencoTitoli(List<Titolo> titoli, TreeListNode nodo)
        {
            foreach (TreeListNode item in nodo.Nodes)
            {
                if (!item.HasChildren)
                {
                    Titolo titolo = item.Tag as Titolo;
                    item.Checked = titoli.Contains(titolo);
                }
                else
                    ApplyElencoTitoli(titoli, item);
            }
        }

        internal int ApplyElencoTitoli(GestoreProfili gestoreProfili, TreeList albero, bool scuola)
        {
            int num = 0;

            List<ProfiloCliente> elenco = new List<ProfiloCliente>();
            foreach (TreeListNode item in albero.Nodes)
            {
                if (item.HasChildren)
                    num += ApplyElencoTitoli(gestoreProfili, item, albero, elenco, scuola);
                else
                {
                    Titolo titolo = item.Tag as Titolo;
                    foreach (ProfiloCliente profilo in gestoreProfili.ElencoProfili)
                    {
                        if (profilo.Scuola != scuola)
                            continue;

                        if ((titolo != null && profilo.ElencoTitoli.Contains(titolo)) ||
                            (titolo == null && profilo.ElencoTitoli.Count == 0))
                        {
                            if (!elenco.Contains(profilo))
                            {
                                item.SetValue(albero.Columns[3], profilo.NumeroPersone);
                                elenco.Add(profilo);
                                num++;
                            }
                        }
                    }
                }
            }

            return num;
        }

        private int ApplyElencoTitoli(GestoreProfili gestoreProfili, TreeListNode nodo, TreeList albero, List<ProfiloCliente> elenco, bool scuola)
        {
            int num = 0;
            foreach (TreeListNode item in nodo.Nodes)
            {
                if (item.HasChildren)
                    num += ApplyElencoTitoli(gestoreProfili, item, albero, elenco, scuola);
                else
                {
                    Titolo titolo = item.Tag as Titolo;
                    foreach (ProfiloCliente profilo in gestoreProfili.ElencoProfili)
                    {
                        if (profilo.Scuola != scuola)
                            continue;

                        if ((titolo != null && profilo.ElencoTitoli.Contains(titolo)) ||
                            (titolo == null && profilo.ElencoTitoli.Count == 0))
                        {
                            if (!elenco.Contains(profilo))
                            {
                                item.SetValue(albero.Columns[3], profilo.NumeroPersone);
                                elenco.Add(profilo);
                                num++;
                            }
                        }
                    }
                }
            }

            return num;
        }

        private void BuildTreeTitoli(TreeList albero)
        {
            albero.BeginUnboundLoad();
            albero.ClearNodes();

            foreach (string gruppo in Titolo.GetAllGroups(m_Uow))
            {
                TreeListNode capogruppo = null;

                foreach (Titolo item in m_ElencoTitoli)
                {
                    if (item.Gruppo == gruppo)
                    {
                        if (capogruppo == null)
                            capogruppo = albero.AppendNode(new object[] { gruppo }, null);

                        TreeListNode nodo = albero.AppendNode(new object[] { item.Descrizione, item.Ridotto, item.Omaggio }, capogruppo);
                        nodo.Tag = item;
                    }
                }
            }
            foreach (Titolo item in m_ElencoTitoli)
            {
                if (string.IsNullOrEmpty(item.Gruppo))
                {
                    TreeListNode nodo = albero.AppendNode(new object[] { item.Descrizione, item.Ridotto, item.Omaggio }, null);
                    nodo.Tag = item;
                }
            }

            albero.EndUnboundLoad();
            albero.BestFitColumns();
        }
    }
}

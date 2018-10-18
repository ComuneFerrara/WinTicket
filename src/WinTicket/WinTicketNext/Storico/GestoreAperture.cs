using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Musei.Module;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;

namespace WinTicketNext.Storico
{
    class GestoreAperture
    {
        public Dictionary<Guid, GestioneApertureIngresso> Elenco { get; private set; }

        public GestoreAperture()
        {
            Elenco = new Dictionary<Guid,GestioneApertureIngresso>();
        }

        public void Add(Guid id, DateTime data)
        {
            GestioneApertureIngresso item;

            if (!Elenco.TryGetValue(id, out item))
            {
                item = new GestioneApertureIngresso(id);
                Elenco.Add(id, item);
            }

            item.Add(data);
        }

        public bool Valido(Guid id, DateTime dataContabile)
        {
            GestioneApertureIngresso item;

            if (Elenco.TryGetValue(id, out item))
            {
                //DateTime data = inizioval.Date;
                //while (data <= fineval)
                //{
                //    if (item.Esiste(data))
                //        return true;

                //    data = data.AddDays(1);
                //}

                if (item.Esiste(dataContabile.Date)) return true;

                return false;
            }
            else
                return false;
        }

        internal bool Contiene(Guid id, DateTime data)
        {
            GestioneApertureIngresso item;

            if (Elenco.TryGetValue(id, out item))
            {
                return item.Esiste(data);
            }
            else
                return false;
        }

        public void CaricaApertureIngressi(DateTime inizio, DateTime fine, UnitOfWork uow)
        {
            XPCollection<PostazioneAccesso> accessi = new XPCollection<PostazioneAccesso>(uow);
            GroupOperator periodoa1 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                                    new BinaryOperator("Data", inizio, BinaryOperatorType.GreaterOrEqual),
                                    new BinaryOperator("Data", fine, BinaryOperatorType.LessOrEqual)});
            accessi.Criteria = periodoa1;
            foreach (PostazioneAccesso postazioneAccesso in accessi)
            {
                if (postazioneAccesso.Postazione != null && !postazioneAccesso.Postazione.Opzione("[NOACCESSI]"))
                {
                    foreach (PostazioneIngresso postazioneIngresso in postazioneAccesso.Postazione.Ingressi)
                    {
                        Add(postazioneIngresso.Ingresso.Oid, postazioneAccesso.Data);
                    }
                }

                // mai valorizzato
                if (postazioneAccesso.Ingresso != null)
                    Add(postazioneAccesso.Ingresso.Oid, postazioneAccesso.Data);
            }

            bool mostraCasoA = true;
            bool mostraCasoB = true;

            XPCollection<Vendita> vendite = new XPCollection<Vendita>(uow);
            GroupOperator periodoa2 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                                    new BinaryOperator("DataContabile", inizio, BinaryOperatorType.GreaterOrEqual),
                                    new BinaryOperator("DataContabile", fine, BinaryOperatorType.LessOrEqual)});
            vendite.Criteria = periodoa2;
            foreach (Vendita vendita in vendite)
            {
                /* nuova maniera, prende solo se marcata con INS.STORICO */

                if (vendita.Postazione.Opzione("[INS.STORICO]"))
                {
                    foreach (var stampa in vendita.Stampe)
                    {
                        foreach (RigaStampaIngresso rsi in stampa.RigheStampaIngresso)
                        {
                            if (rsi.Ingresso.IsAttrib("[INS.STORICO]"))
                            {
                                if (rsi.Ingresso.IsAttrib("[VENDITA=APERTURA]"))
                                    Add(rsi.Ingresso.Oid, vendita.DataContabile);
                            }
                            else
                            {
                                if (mostraCasoA)
                                {
                                    XtraMessageBox.Show("Vendita da una postazione per INSERIMENTO STORICO: " + vendita.Postazione.Nome + " per " +
                                        rsi.Ingresso.Descrizione + " / " + vendita.DataContabile + " / " +
                                                        vendita.CodiceLeggibile);
                                    XtraMessageBox.Show("altri messaggi ti questo tipo verranno sopressi");
                                }

                                mostraCasoA = false;
                                //throw new Exception("Questo non permette di proseguire (caso A).");
                            }
                        }
                    }
                }
                else
                {
                    if (vendita.Postazione.Tipologia == EnumTipologiaPostazione.NonAttiva)
                    {
                        if (mostraCasoB)
                        {
                            XtraMessageBox.Show("Vendita da postazione attualmente NON attiva: " + vendita.Postazione.Nome + " / " + vendita.Postazione.MachineName);
                            XtraMessageBox.Show("altri messaggi ti questo tipo verranno sopressi");
                        }

                        mostraCasoB = false;
                        //throw new Exception("Questo non permette di proseguire (caso B).");
                    }
                }

                /* vechia maniera di calcolo */

                //// la postazione era aperta in quella data ... di conseguenza anche gli ingressi associati ...
                //foreach (PostazioneIngresso postazioneIngresso in vendita.Postazione.Ingressi)
                //{
                //    if (!postazioneIngresso.Ingresso.IsAttrib("[NotOpenOnSell]"))
                //        Add(postazioneIngresso.Ingresso.Oid, vendita.DataContabile);
                //}

                //// se non ci sono ingressi associati alla postazione, vuol dire che e' un inserimento di un dato storico,
                //// considero aperto il museo in quella data ...
                //if (vendita.Postazione.Ingressi.Count == 0)
                //{
                //    foreach (var stampa in vendita.Stampe)
                //    {
                //        foreach (RigaStampaIngresso rsi in stampa.RigheStampaIngresso)
                //        {
                //            if (!rsi.Ingresso.IsAttrib("[NotOpenOnSell]"))
                //                Add(rsi.Ingresso.Oid, vendita.DataContabile);
                //        }
                //    }
                //}

            }

            // stampa le date
            //foreach (var item in Elenco)
            //{
            //    Console.WriteLine(item.Value.Ingresso);
            //    item.Value.Aperture.Sort();
            //    foreach (var dateTime in item.Value.Aperture)
            //    {
            //        Console.WriteLine("{0:d}", dateTime);
                    
            //    }
            //}

        }

        internal int TotaleGiornate(Guid id, DateTime inizio, DateTime fine)
        {
            int ng = 0;
            DateTime data = inizio;
            while (data <= fine)
            {
                if (Contiene(id, data)) ng++;
                data = data.AddDays(1);
            }
            return ng;
        }
    }
}
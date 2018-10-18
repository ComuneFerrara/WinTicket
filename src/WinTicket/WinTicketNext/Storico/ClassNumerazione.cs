using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Musei.Module;

namespace WinTicketNext.Storico
{
    public class ClassNumerazione
    {
        public Dictionary<Postazione, ClassNumerazionePostazione> Elenco { get; private set; }

        public ClassNumerazione()
        {
            Elenco = new Dictionary<Postazione, ClassNumerazionePostazione>();
        }

        internal void Add(Postazione postazione, int number, int anno)
        {
            if (!Elenco.ContainsKey(postazione))
            {
                Elenco.Add(postazione, new ClassNumerazionePostazione(postazione));
            }

            Elenco[postazione].Add(number, anno);
        }

        internal int NB(Postazione postazione)
        {
            if (Elenco.ContainsKey(postazione))
                return Elenco[postazione].NB();
            else
                return 0;
        }

        internal string EB(Postazione postazione)
        {
            if (Elenco.ContainsKey(postazione))
                return Elenco[postazione].EB();
            else
                return string.Empty;
        }

        internal string EB()
        {
            string result = string.Empty;
            foreach (KeyValuePair<Postazione, ClassNumerazionePostazione> keyValuePairPostazione in Elenco)
            {
                result += keyValuePairPostazione.Value.EB() + Environment.NewLine;
            }
            return result;
        }
        internal int NB()
        {
            int result = 0;
            foreach (KeyValuePair<Postazione, ClassNumerazionePostazione> keyValuePairPostazione in Elenco)
            {
                result += keyValuePairPostazione.Value.NB();
            }
            return result;
        }
    }

    public class ClassNumerazionePostazione
    {
        public Postazione Postazione { get; private set; }
        public List<ClassNumerazioneSet> Insiemi { get; private set; }

        public ClassNumerazionePostazione(Postazione postazione)
        {
            Postazione = postazione;
            Insiemi = new List<ClassNumerazioneSet>();
        }

        public void Add(int number, int anno)
        {
            bool inserito = false;
            foreach (ClassNumerazioneSet classNumerazioneSet in Insiemi)
            {
                if (classNumerazioneSet.Add(number, anno))
                {
                    inserito = true;
                    break;
                }
            }

            if (!inserito)
                Insiemi.Add(new ClassNumerazioneSet(number, anno));

            bool merged = false;
            do
            {
                merged = false;
                for (int i = 0; i < Insiemi.Count; i++)
                {
                    for (int j = i + 1; j < Insiemi.Count; j++)
                    {
                        if (Insiemi[i].CanMergeWith(Insiemi[j]))
                        {
                            Insiemi[i].Merge(Insiemi[j]);
                            Insiemi.Remove(Insiemi[j]);
                            merged = true;
                        }
                    }
                }
            } while (merged);

            Insiemi.Sort();
        }

        internal int NB()
        {
            int totale = 0;
            foreach (ClassNumerazioneSet classNumerazioneSet in Insiemi)
            {
                totale += (classNumerazioneSet.Upper - classNumerazioneSet.Lower) + 1;
            }
            return totale;
        }

        internal string EB()
        {
            string result = string.Empty;
            foreach (ClassNumerazioneSet classNumerazioneSet in Insiemi)
            {
                result += (string.IsNullOrEmpty(result) ? "" : ", ") +
                    string.Format("{0}-{1}", classNumerazioneSet.Lower, classNumerazioneSet.Upper);
            }
            return result;
        }
    }

    public class ClassNumerazioneSet : IComparable
    {
        public int Year { get; private set; }
        public int Upper { get; private set; }
        public int Lower { get; private set; }

        public ClassNumerazioneSet(int first, int year)
        {
            Year = year;
            Upper = Lower = first;
        }

        public bool Add(int number, int year)
        {
            if (year != Year) return false;

            if (number >= Lower && number <= Upper)
                return true;

            if (number == Upper + 1)
            {
                Upper = number;
                return true;
            }

            if (number == Lower - 1)
            {
                Lower = number;
                return true;
            }

            return false;
        }

        internal bool CanMergeWith(ClassNumerazioneSet target)
        {
            if (target.Year != Year) return false;

            if (Upper == target.Lower - 1 || Lower == target.Upper + 1)
                return true;
            else
                return false;
        }

        internal void Merge(ClassNumerazioneSet target)
        {
            Upper = Math.Max(Upper, target.Upper);
            Lower = Math.Min(Lower, target.Lower);
        }

        int IComparable.CompareTo(object obj)
        {
            ClassNumerazioneSet target = obj as ClassNumerazioneSet;
            if (Year == target.Year)
                return Lower - target.Lower;
            else
                return Year - target.Year;
        }
    }
}

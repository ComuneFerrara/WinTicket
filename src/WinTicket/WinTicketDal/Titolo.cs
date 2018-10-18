using System;

using DevExpress.Xpo;
using System.Collections.Generic;

namespace Musei.Module
{
    public class Titolo : MuseiBase
    {
        private string m_Descrizione;
        [Indexed(Unique=true)]
        public string Descrizione
        {
            get
            {
                return m_Descrizione;
            }
            set
            {
                SetPropertyValue("Descrizione", ref m_Descrizione, value);
            }
        }

        private string m_Gruppo;
        public string Gruppo
        {
            get
            {
                return m_Gruppo;
            }
            set
            {
                SetPropertyValue("Gruppo", ref m_Gruppo, value);
            }
        }

        private string m_Sconto;
        public string Sconto
        {
            get
            {
                return m_Sconto;
            }
            set
            {
                SetPropertyValue("Sconto", ref m_Sconto, value);
            }
        }

        // per MOBILITY CARD + ACCOMPAGNATORI
        private Titolo m_TitoloPrincipale;
        public Titolo TitoloPrincipale
        {
            get
            {
                return m_TitoloPrincipale;
            }
            set
            {
                SetPropertyValue("TitoloPrincipale", ref m_TitoloPrincipale, value);
            }
        }

        // per MOBILITY CARD + ACCOMPAGNATORI
        private Titolo m_TitoloSecondario;
        public Titolo TitoloSecondario
        {
            get
            {
                return m_TitoloSecondario;
            }
            set
            {
                SetPropertyValue("TitoloSecondario", ref m_TitoloSecondario, value);
            }
        }

        private int _Priority;
        public int Priority
        {
            get
            {
                return _Priority;
            }
            set
            {
                SetPropertyValue("Priority", ref _Priority, value);
            }
        }

        private string _Attributi;
        public string Attributi
        {
            get
            {
                return _Attributi;
            }
            set
            {
                SetPropertyValue("Attributi", ref _Attributi, value);
            }
        }

        [Association("Variante-Titolo", UseAssociationNameAsIntermediateTableName = true)]
        public XPCollection<Variante> ElencoVarianti
        {
            get
            {
                return GetCollection<Variante>("ElencoVarianti");
            }
        }

        [Association("Titolo-TitoliCompresi", UseAssociationNameAsIntermediateTableName = true)]
        public XPCollection<Titolo> TitoliCompresi
        {
            get
            {
                return GetCollection<Titolo>("TitoliCompresi");
            }
        }

        [Association("Titolo-TitoliCompresi", UseAssociationNameAsIntermediateTableName = true)]
        public XPCollection<Titolo> CompresoNeiTitoli
        {
            get
            {
                return GetCollection<Titolo>("CompresoNeiTitoli");
            }
        }

        private string m_Ridotto;
        [NonPersistent]
        public string Ridotto
        {
            get { return m_Ridotto; }
            set
            {
                m_Ridotto = value;
            }
        }

        private string m_Omaggio;
        [NonPersistent]
        public string Omaggio
        {
            get { return m_Omaggio; }
            set
            {
                m_Omaggio = value;
            }
        }                

        public Titolo(Session session) : base(session) { }

        public static string[] GetAllGroups(Session uow)
        {
            XPCollection<Titolo> collection = new XPCollection<Titolo>(uow);

            List<string> elenco = new List<string>();
            foreach (Titolo item in collection)
            {
                if (!string.IsNullOrEmpty(item.Gruppo))
                {
                    if (!elenco.Contains(item.Gruppo))
                        elenco.Add(item.Gruppo);
                }
            }

            return elenco.ToArray();
        }

        public bool IsAttrib(string request)
        {
            if (string.IsNullOrEmpty(Attributi))
                return false;
            else
                return Attributi.ToUpper().Contains(request.ToUpper());
        }

        public bool Bonus()
        {
            if (string.IsNullOrEmpty(Sconto)) return false;
            if (Sconto.ToLower() == "[bonus]") return true;
            return false;
        }
    }

}

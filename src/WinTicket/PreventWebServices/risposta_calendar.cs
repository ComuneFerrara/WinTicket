﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.1
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Codice sorgente generato automaticamente da xsd, versione=4.0.30319.1.
// 
namespace prevent.calendar {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Out {
        
        private OutSitoCalendario[] sitoCalendarioField;
        
        private string returnCodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SitoCalendario")]
        public OutSitoCalendario[] SitoCalendario {
            get {
                return this.sitoCalendarioField;
            }
            set {
                this.sitoCalendarioField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ReturnCode {
            get {
                return this.returnCodeField;
            }
            set {
                this.returnCodeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class OutSitoCalendario {
        
        private string idSitoField;
        
        private OutSitoCalendarioGiornata[] giornataField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="positiveInteger")]
        public string IdSito {
            get {
                return this.idSitoField;
            }
            set {
                this.idSitoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Giornata")]
        public OutSitoCalendarioGiornata[] Giornata {
            get {
                return this.giornataField;
            }
            set {
                this.giornataField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class OutSitoCalendarioGiornata {
        
        private System.DateTime dataField;
        
        private string noteField;
        
        private OutSitoCalendarioGiornataPeriodo[] periodoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime Data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
            }
        }
        
        /// <remarks/>
        public string Note {
            get {
                return this.noteField;
            }
            set {
                this.noteField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Periodo")]
        public OutSitoCalendarioGiornataPeriodo[] Periodo {
            get {
                return this.periodoField;
            }
            set {
                this.periodoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class OutSitoCalendarioGiornataPeriodo {
        
        private string oraField;
        
        private string disponibiliField;
        
        private string maxField;
        
        /// <remarks/>
        public string Ora {
            get {
                return this.oraField;
            }
            set {
                this.oraField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="positiveInteger")]
        public string Disponibili {
            get {
                return this.disponibiliField;
            }
            set {
                this.disponibiliField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="positiveInteger")]
        public string Max {
            get {
                return this.maxField;
            }
            set {
                this.maxField = value;
            }
        }
    }
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("MijnEigenMooieUniekeNamespace-Producten-V2", ClrNamespace="MijnEigenMooieUniekeNamespaceProductenV2")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("MijnEigenMooieUniekeNamespace-V2", ClrNamespace="MijnEigenMooieUniekeNamespaceV2")]

namespace MijnEigenMooieUniekeNamespaceProductenV2
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="Producten", Namespace="MijnEigenMooieUniekeNamespace-Producten-V2", ItemName="Product")]
    public class Producten : System.Collections.Generic.List<MijnEigenMooieUniekeNamespaceProductenV2.Product>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="MijnEigenMooieUniekeNamespace-Producten-V2")]
    public partial class Product : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string NaamField;
        
        private decimal PrijsField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string Naam
        {
            get
            {
                return this.NaamField;
            }
            set
            {
                this.NaamField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Prijs
        {
            get
            {
                return this.PrijsField;
            }
            set
            {
                this.PrijsField = value;
            }
        }
    }
}
namespace MijnEigenMooieUniekeNamespaceV2
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Persoon", Namespace="MijnEigenMooieUniekeNamespace-V2")]
    public partial class Persoon : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string NaamField;
        
        private string AchternaamField;
        
        private System.DateTime GeboortedatumField;
        
        private MijnEigenMooieUniekeNamespaceProductenV2.Producten ProductenField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string Naam
        {
            get
            {
                return this.NaamField;
            }
            set
            {
                this.NaamField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=1)]
        public string Achternaam
        {
            get
            {
                return this.AchternaamField;
            }
            set
            {
                this.AchternaamField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public System.DateTime Geboortedatum
        {
            get
            {
                return this.GeboortedatumField;
            }
            set
            {
                this.GeboortedatumField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=3)]
        public MijnEigenMooieUniekeNamespaceProductenV2.Producten Producten
        {
            get
            {
                return this.ProductenField;
            }
            set
            {
                this.ProductenField = value;
            }
        }
    }
}

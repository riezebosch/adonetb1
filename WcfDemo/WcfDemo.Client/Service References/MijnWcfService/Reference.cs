﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfDemo.Client.MijnWcfService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Persoon", Namespace="http://schemas.datacontract.org/2004/07/WcfDemo")]
    [System.SerializableAttribute()]
    public partial class Persoon : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LeeftijdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NaamField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal SalarisField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Leeftijd {
            get {
                return this.LeeftijdField;
            }
            set {
                if ((this.LeeftijdField.Equals(value) != true)) {
                    this.LeeftijdField = value;
                    this.RaisePropertyChanged("Leeftijd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Naam {
            get {
                return this.NaamField;
            }
            set {
                if ((object.ReferenceEquals(this.NaamField, value) != true)) {
                    this.NaamField = value;
                    this.RaisePropertyChanged("Naam");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Salaris {
            get {
                return this.SalarisField;
            }
            set {
                if ((this.SalarisField.Equals(value) != true)) {
                    this.SalarisField = value;
                    this.RaisePropertyChanged("Salaris");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MijnWcfService.IMijnWcfService")]
    public interface IMijnWcfService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMijnWcfService/DoWork", ReplyAction="http://tempuri.org/IMijnWcfService/DoWorkResponse")]
        void DoWork(WcfDemo.Client.MijnWcfService.Persoon p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMijnWcfService/DoWork", ReplyAction="http://tempuri.org/IMijnWcfService/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync(WcfDemo.Client.MijnWcfService.Persoon p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMijnWcfService/Get", ReplyAction="http://tempuri.org/IMijnWcfService/GetResponse")]
        WcfDemo.Client.MijnWcfService.Persoon Get(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMijnWcfService/Get", ReplyAction="http://tempuri.org/IMijnWcfService/GetResponse")]
        System.Threading.Tasks.Task<WcfDemo.Client.MijnWcfService.Persoon> GetAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMijnWcfServiceChannel : WcfDemo.Client.MijnWcfService.IMijnWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MijnWcfServiceClient : System.ServiceModel.ClientBase<WcfDemo.Client.MijnWcfService.IMijnWcfService>, WcfDemo.Client.MijnWcfService.IMijnWcfService {
        
        public MijnWcfServiceClient() {
        }
        
        public MijnWcfServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MijnWcfServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MijnWcfServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MijnWcfServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork(WcfDemo.Client.MijnWcfService.Persoon p) {
            base.Channel.DoWork(p);
        }
        
        public System.Threading.Tasks.Task DoWorkAsync(WcfDemo.Client.MijnWcfService.Persoon p) {
            return base.Channel.DoWorkAsync(p);
        }
        
        public WcfDemo.Client.MijnWcfService.Persoon Get(int id) {
            return base.Channel.Get(id);
        }
        
        public System.Threading.Tasks.Task<WcfDemo.Client.MijnWcfService.Persoon> GetAsync(int id) {
            return base.Channel.GetAsync(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfDemo
{
    [DataContract(Name="Persoon")]
    public class PersoonDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Naam { get; set; }

        [DataMember]
        public int Leeftijd { get; set; }

        [DataMember]
        public decimal Salaris { get; set; }
    }
}

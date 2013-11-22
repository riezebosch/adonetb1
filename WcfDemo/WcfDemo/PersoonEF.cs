using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfDemo
{
    public class PersoonEF
    {
        public virtual int Id { get; set; }

        public virtual string VolledigeNaam { get; set; }

        public virtual int Leeftijd { get; set; }

        public virtual decimal Salaris { get; set; }
    }
}

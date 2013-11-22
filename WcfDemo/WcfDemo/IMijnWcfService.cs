using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMijnWcfService" in both code and config file together.
    [ServiceContract]
    public interface IMijnWcfService
    {
        [OperationContract]
        void DoWork(PersoonDTO p);

        [OperationContract]
        PersoonDTO Get(int id);
    }
}

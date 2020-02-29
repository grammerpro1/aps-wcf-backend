using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIWcf
{
    [DataContract]
    public class CompraRequest
    {
        [DataMember]
        public String Pan { get; set; }

        [DataMember]
        public String Cvc { get; set; }

        [DataMember]
        public String Vto { get; set; }

        [DataMember]
        public String IdCliente { get; set; }

        [DataMember]
        public String IdComercio { get; set; }

        [DataMember]
        public String IdMoneda { get; set; }

        [DataMember]
        public int Cuotas { get; set; }

        [DataMember]
        public String IdSello { get; set; }

        [DataMember]
        public String Sello { get; set; }

        [DataMember]
        public decimal Monto { get; set; }
    }
}
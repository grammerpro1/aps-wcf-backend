using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIWcf
{
    [DataContract]
    public class TransaccionInfo
    {
        [DataMember]
        public string IdCliente { get; set; }

        [DataMember]
        public TransaccionResultado Estado { get; set; }

        [DataMember]
        public string CodigoTransaccion { get; set; }

        [DataMember]
        public string MensajeTransaccion { get; set; }

        [DataMember]
        public string CodigoAutorizacion { get; set; }

        [DataMember]
        public string RRNTransaccion { get; set; }
        [DataMember]
        public long IdTransaccionInfo { get; set; }

    }
}
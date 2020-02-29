using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIWcf
{
    [DataContract]
    public class ComercioTarjetaRequest
    {
        [DataMember]
        public long IdComercio { get; set; }
        [DataMember]
        public int IdTarjeta { get; set; }
        [DataMember]
        public String Metadata { get; set; }

    }
}
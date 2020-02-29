using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIWcf
{
    [DataContract]
    public class ComercioTarjeta
    {
        [DataMember]
        public int IdComercioTarjeta { get; set; }
        [DataMember]
        public long IdComercio { get; set; }
        [DataMember]
        public int IdTarjeta { get; set; }
        [DataMember]
        public String NombreTarjeta { get; set; }
        [DataMember]

        public String Metadata { get; set; }
        

    }
}
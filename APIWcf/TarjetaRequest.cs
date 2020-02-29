using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIWcf
{
    [DataContract]
    public class TarjetaRequest
    {
       
        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public int Activa { get; set; }

    }
}
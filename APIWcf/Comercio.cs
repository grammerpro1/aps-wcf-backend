using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIWcf
{
    [DataContract]
    public class Comercio
    {
        [DataMember]
        public long IdComercio { get; set; }

        [DataMember]
        public String Nombre { get; set; }

    }
}
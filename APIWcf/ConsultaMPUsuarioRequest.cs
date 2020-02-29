using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIWcf
{
    [DataContract]
    public class ConsultaMPUsuarioRequest
    {
        [DataMember]
        public int IdCliente { get; set; }

    }
    
}
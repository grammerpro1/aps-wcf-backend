using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIWcf
{
    [DataContract]
    public class Login
    {
        [DataMember]
        public String NombreUsuario { get; set; }
        [DataMember]
        public String Password { get; set; }
        [DataMember]
        public long IdUsuario { get; set; }
    }
}
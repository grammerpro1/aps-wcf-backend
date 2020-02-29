using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIWcf
{
    [DataContract]
    public class LoginRequest
    {
        [DataMember]
        public String NombreUsuario { get; set; }
        [DataMember]
        public String Password { get; set; }
    }
}
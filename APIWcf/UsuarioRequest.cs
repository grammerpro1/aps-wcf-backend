using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIWcf
{
    [DataContract]
    public class UsuarioRequest
    {
        [DataMember]
        public String PrimerApellido { get; set; }
        [DataMember]
        public String PrimerNombre { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public long IdComercio { get; set; }
        [DataMember]
        public String NombreUsuario { get; set; }
        [DataMember]
        public String Password { get; set; }

    }
}
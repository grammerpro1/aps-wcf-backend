using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIWcf
{
    [DataContract]
    public class ConsultaMPUsuario
    {
        [DataMember]
        public int IdCliente { get; set; }

        [DataMember]
        public ArrayList ListaMPUsuario { get; set; }//Contiene los MP asociados al usuario

        public ConsultaMPUsuario()
        {
            ListaMPUsuario = new ArrayList();
        }
    }
    
}
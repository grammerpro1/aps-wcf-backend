using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIWcf
{
    [DataContract]
    public class ConsultaMPComercio
    {
        [DataMember]
        public int IdComercio { get; set; }

        [DataMember]
        public ArrayList ListaMPComercio { get; set; }//Contiene los MP asociados al comercio

        public ConsultaMPComercio()
        {
            ListaMPComercio = new ArrayList();
        }
    }
}
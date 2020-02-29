using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIWcf
{
    [DataContract]
    public class TarjetaClienteRequest
    {
        
        [DataMember]
        public String Proveedor { get; set; }
        [DataMember]
        public int IdCliente { get; set; }
        [DataMember]
        public String NumeroTarjeta { get; set; }
        [DataMember]
        public DateTime Expiracion { get; set; }
        [DataMember]
        public DateTime FechaCreacion { get; set; }
        [DataMember]
        public int Activa { get; set; }
        [DataMember]
        public int EstadoExpirada { get; set; }
        [DataMember]
        public int IdTarjeta { get; set; }
    }
}
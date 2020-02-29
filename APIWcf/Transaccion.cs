using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace APIWcf
{
    [DataContract]
    public class Transaccion
    {
        [DataMember]
        public string IdTransaccion { get; set; }

        [DataMember]
        public String Comercio { get; set; }

        [DataMember]
        public string IdSello { get; set; }

        [DataMember]
        public string Pan { get; set; }

        [DataMember]
        public String Sello { get; set; }

        [DataMember]
        public decimal Monto { get; set; }

        [DataMember]
        public int Cuotas { get; set; }

        [DataMember]
        public String IdMoneda { get; set; }

        [DataMember]
        public String EstadoTransaccion { get; set; }//Estado de la transaccion actualmente, reversada, anulada, autorizada.

        [DataMember]
        public Dictionary<String, TransaccionInfo> Transacciones { get; set; }//Contiene las transacciones asociadas, reversas, anulaciones, devoluciones

        [DataMember]
        public Dictionary<String, String> DatosAdicionales { get; set; }//Datos del cliente y tarjeta
        [DataMember]
        public DateTime FechaTransaccion { get; set; }
        [DataMember]
        public String MTI { get; set; }
        [DataMember]
        public String Processcod { get; set; }

        public Transaccion()
        {
            DatosAdicionales = new Dictionary<string, string>();
            Transacciones = new Dictionary<string, TransaccionInfo>();
        }
    }
}
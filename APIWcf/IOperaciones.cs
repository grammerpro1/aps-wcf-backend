using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace APIWcf
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IOperaciones
    {
        // TODO: agregue aquí sus operaciones de servicio
        [OperationContract]
        [WebInvoke(UriTemplate = "Operacion/Compra", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        String Compra(CompraRequest xCompra);

        [OperationContract]
        [WebInvoke(UriTemplate = "Operacion/AltaComercio", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        String AltaComercio(ComercioRequest xComercio);

        [OperationContract]
        [WebInvoke(UriTemplate = "Operacion/AltaTarjeta", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        String AltaTarjeta(TarjetaRequest xTarjeta);

        [OperationContract]
        [WebInvoke(UriTemplate = "Operacion/ComercioTarjeta", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        String ComercioTarjeta(ComercioTarjetaRequest xComercioTarjeta);

        [OperationContract]
        [WebInvoke(UriTemplate = "Operacion/AltaUsuario", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        String AltaUsuario(UsuarioRequest xUsuario);

        [OperationContract]
        [WebInvoke(UriTemplate = "Operacion/AltaTarjetaCliente", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        String AltaTarjetaCliente(TarjetaClienteRequest xTarjetaCliente);

        [OperationContract]
        [WebInvoke(UriTemplate = "Operacion/ConsultaMPUsuario", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        String ConsultaMPUsuario(ConsultaMPUsuarioRequest xConsulta);

        [OperationContract]
        [WebInvoke(UriTemplate = "Operacion/Login", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        String Login(LoginRequest xLogin);

        [OperationContract]
        [WebInvoke(UriTemplate = "Operacion/ConsultaMPComercio", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        String ConsultaMPComercio(ConsultaMPComercioRequest xConsulta);
    }
}

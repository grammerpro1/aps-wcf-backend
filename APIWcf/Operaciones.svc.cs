using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using Trx.Messaging.Iso8583;
using Trx.Messaging;
using Trx.Communication.Channels.Tcp;
using Trx.Communication.Channels;
using Trx.Communication.Channels.Sinks;
using Trx.Communication.Channels.Sinks.Framing;
using Trx.Logging;
using Trx.Coordination.TupleSpace;
using System.Configuration;
using System.Collections;

namespace APIWcf
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Operaciones" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Operaciones.svc o Operaciones.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Operaciones : IOperaciones
    {
        public string AltaComercio(ComercioRequest xComercio)
        {
            string respuestaJSON = null;

            try
            {
                //1-Se crea el comercio
                Comercio oComercio = new Comercio();
                long IdComercio = ConsultasBD.GenerarIdComercio();
                oComercio.IdComercio = IdComercio;
                oComercio.Nombre = xComercio.Nombre;

                //2-Se guarda el comercio en la BD
                ConsultasBD.InsertarComercio(oComercio);

                //3-Se retorna el json al cliente.
                respuestaJSON = JsonConvert.SerializeObject(oComercio);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Error en AltaComercio: " + ex.ToString());
            }
            return respuestaJSON;
        }

        public string AltaTarjeta(TarjetaRequest xTarjeta)
        {
            string respuestaJSON = null;

            try
            {
                //1-Se crea la tarjeta
                Tarjeta oTarjeta = new Tarjeta();
                int IdTarjeta = ConsultasBD.GenerarIdTarjeta();
                oTarjeta.IdTarjeta = IdTarjeta;
                oTarjeta.Nombre = xTarjeta.Nombre;
                oTarjeta.Activa = xTarjeta.Activa;

                //2-Se guarda la tarjeta en la BD
                ConsultasBD.InsertarTarjeta(oTarjeta);

                //3-Se retorna el json al cliente.
                respuestaJSON = JsonConvert.SerializeObject(oTarjeta);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Error en AltaTarjeta: " + ex.ToString());
            }
            return respuestaJSON;
        }

        public string AltaTarjetaCliente(TarjetaClienteRequest xTarjetaCliente)
        {
            string respuestaJSON = null;

            try
            {
                //1-Se crea la TarjetaCliente
                TarjetaCliente oTarjetaCliente = new TarjetaCliente();
                long idTarjetaCliente = ConsultasBD.GenerarIdTarjetaCliente();
                oTarjetaCliente.IdTarjetaCliente = idTarjetaCliente;
                oTarjetaCliente.Proveedor = xTarjetaCliente.Proveedor;
                oTarjetaCliente.IdCliente = xTarjetaCliente.IdCliente;
                oTarjetaCliente.NumeroTarjeta = xTarjetaCliente.NumeroTarjeta;
                oTarjetaCliente.Expiracion = xTarjetaCliente.Expiracion;
                oTarjetaCliente.FechaCreacion = xTarjetaCliente.FechaCreacion;
                oTarjetaCliente.Activa = xTarjetaCliente.Activa;
                oTarjetaCliente.EstadoExpirada = xTarjetaCliente.EstadoExpirada;
                oTarjetaCliente.IdTarjeta = xTarjetaCliente.IdTarjeta;

                //2-Se guarda TarjetaCliente en la BD
                ConsultasBD.InsertarTarjetaCliente(oTarjetaCliente);

                //3-Se retorna el json al cliente.
                respuestaJSON = JsonConvert.SerializeObject(oTarjetaCliente);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Error en AltaTarjetaCliente: " + ex.ToString());
            }
            return respuestaJSON;
        }

        public string AltaUsuario(UsuarioRequest xUsuario)
        {
            string respuestaJSON = null;

            try
            {
                //1-Se crea el usuario
                Usuario oUsuario = new Usuario();
                int IdUsuario = ConsultasBD.GenerarIdCliente();
                oUsuario.IdUsuario = IdUsuario;
                oUsuario.PrimerApellido = xUsuario.PrimerApellido;
                oUsuario.PrimerNombre = xUsuario.PrimerNombre;
                oUsuario.Email = xUsuario.Email;
                oUsuario.IdComercio = xUsuario.IdComercio;
                oUsuario.NombreUsuario = xUsuario.NombreUsuario;
                oUsuario.Password = xUsuario.Password;

                //2-Se guarda el usuario en la BD
                ConsultasBD.InsertarUsuario(oUsuario);

                //3-Se retorna el json al cliente.
                respuestaJSON = JsonConvert.SerializeObject(oUsuario);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Error en AltaUsuario: " + ex.ToString());
            }
            return respuestaJSON;
        }

        public string ComercioTarjeta(ComercioTarjetaRequest xComercioTarjeta)
        {
            string respuestaJSON = null;

            try
            {
                //1-Se crea el objeto
                ComercioTarjeta oComercioTarjeta = new ComercioTarjeta();
                int idComercioTarjeta = ConsultasBD.GenerarIdComercioTarjeta();
                oComercioTarjeta.IdComercioTarjeta = idComercioTarjeta;
                oComercioTarjeta.IdComercio = xComercioTarjeta.IdComercio;
                oComercioTarjeta.IdTarjeta = xComercioTarjeta.IdTarjeta;
                oComercioTarjeta.Metadata = xComercioTarjeta.Metadata;

                //2-Se guarda el objeto en la BD
                ConsultasBD.InsertarComercioTarjeta(oComercioTarjeta);

                //3-Se retorna el json al cliente.
                respuestaJSON = JsonConvert.SerializeObject(oComercioTarjeta);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Error en ComercioTarjeta: " + ex.ToString());
            }
            return respuestaJSON;
        }

        public string Compra(CompraRequest xCompra)
        {
            string respuestaJSON = null;
            TransaccionInfo oTranInfo = null;

            try
            {
                //1-Se crea la transaccion
                Transaccion oTransaccion = new Transaccion();
                oTransaccion.IdTransaccion = ConsultasBD.GenerarIdTransaccion().ToString();
                oTransaccion.Comercio = xCompra.IdComercio;
                oTransaccion.Pan = xCompra.Pan;
                oTransaccion.IdSello = xCompra.IdSello;
                oTransaccion.Sello = xCompra.Sello;
                oTransaccion.Monto = xCompra.Monto;
                oTransaccion.Cuotas = xCompra.Cuotas;
                oTransaccion.IdMoneda = xCompra.IdMoneda;
                oTransaccion.EstadoTransaccion = "0";
                oTransaccion.FechaTransaccion = DateTime.Now;
                oTransaccion.MTI = "0200";
                oTransaccion.Processcod = "000000";

                //2-Se guarda la transaccion en la BD
                ConsultasBD.InsertarTransaccion(oTransaccion);

                //3-Se envia la transaccion al medio de pago
                DateTime transmissionDate = DateTime.Now;

                //Se construye el mensaje ISO8583.
                string monto = oTransaccion.Monto.ToString().PadLeft(12, '0');
                monto = monto.Replace(",", "").PadLeft(12, '0');

                var msg = new Iso8583Message(200);
                msg.Header = new StringMessageHeader("6000360101");                                         
                msg.Fields.Add(2, oTransaccion.Pan);//numero de tarjeta                                    
                msg.Fields.Add(3, "000000");
                msg.Fields.Add(4, monto);//$100,00
                msg.Fields.Add(7, string.Format("{0}{1}",
                    string.Format("{0:00}{1:00}", transmissionDate.Month, transmissionDate.Day),
                    string.Format("{0:00}{1:00}{2:00}", transmissionDate.Hour,
                        transmissionDate.Minute, transmissionDate.Second)));
                msg.Fields.Add(11, Utils.GetRandomNumber().ToString());
                msg.Fields.Add(12, transmissionDate.Hour.ToString().PadLeft(2, '0') + transmissionDate.Minute.ToString().PadLeft(2, '0') + transmissionDate.Second.ToString().PadLeft(2, '0'));
                msg.Fields.Add(13, transmissionDate.Month.ToString().PadLeft(2, '0') + transmissionDate.Day.ToString().PadLeft(2, '0'));
                msg.Fields.Add(22, "022");
                msg.Fields.Add(24, "36");
                msg.Fields.Add(25, "00");
                msg.Fields.Add(41, "APISW_12");//Terminal
                msg.Fields.Add(42, oTransaccion.Comercio);//Comercio
                msg.Fields.Add(46, "           #0112000000000000");
                msg.Fields.Add(48, oTransaccion.Cuotas.ToString().PadLeft(3,'0'));//Cuotas
                msg.Fields.Add(49, oTransaccion.IdMoneda);
                msg.Fields.Add(60, "40   APISWV1.0     ");
                msg.Fields.Add(61, "10069");
                msg.Fields.Add(62, "0001");//Ticket

                try
                {
                    //Se envia el msg
                    oTranInfo = this.ClientAutorizador(msg);
                }
                catch (Exception ex)
                {//Si ocurre algun error se guarda el mensaje para ser reenviado.
                    throw ex;
                }

                //Se agrega la transaccion de compra a la lista de transacciones asociadas
                oTransaccion.Transacciones.Add("Compra", oTranInfo);

                //5-Se guarda la transaccionInfo en la BD
                oTranInfo.IdCliente = xCompra.IdCliente;
                oTranInfo.IdTransaccionInfo = ConsultasBD.GenerarIdTransaccionInfo();
                ConsultasBD.InsertarTransaccionInfo(oTransaccion, oTranInfo);

                //4-Se retorna el json de la transaccion al cliente.
                respuestaJSON = JsonConvert.SerializeObject(oTransaccion);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Error en Compra");
            }
            return respuestaJSON;
        }

        public string ConsultaMPComercio(ConsultaMPComercioRequest xConsulta)
        {
            string respuestaJSON = null;

            try
            {
                //1-Se crea el objeto
                ConsultaMPComercio oConsulta = new ConsultaMPComercio();
                ArrayList ListaMPComercio = ConsultasBD.ObtenerMPComercio(xConsulta);
                oConsulta.IdComercio = xConsulta.IdComercio;
                oConsulta.ListaMPComercio = ListaMPComercio;

                //2-Se retorna el json al cliente.
                respuestaJSON = JsonConvert.SerializeObject(oConsulta);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Error en ConsultaMPComercio: " + ex.ToString());
            }
            return respuestaJSON;
        }

        public string ConsultaMPUsuario(ConsultaMPUsuarioRequest xConsulta)
        {
            string respuestaJSON = null;

            try
            {
                //1-Se crea el objeto
                ConsultaMPUsuario oConsulta = new ConsultaMPUsuario();
                ArrayList ListaMPUsuario = ConsultasBD.ObtenerMPUsuario(xConsulta);
                oConsulta.IdCliente = xConsulta.IdCliente;
                oConsulta.ListaMPUsuario = ListaMPUsuario;

                //2-Se retorna el json al cliente.
                respuestaJSON = JsonConvert.SerializeObject(oConsulta);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Error en ConsultaMPUsuario: " + ex.ToString());
            }
            return respuestaJSON;
        }

        public string Login(LoginRequest xLogin)
        {
            string respuestaJSON = null;

            try
            {
                //1-Se verifican las credenciales del usuario
                Login oLogin = new Login();
                int IdUsuario = ConsultasBD.VerificarCredencialesUsuario(xLogin);
                if (IdUsuario > 0)
                {
                    oLogin.NombreUsuario = xLogin.NombreUsuario;
                    oLogin.Password = xLogin.Password;
                    oLogin.IdUsuario = IdUsuario;
                }
                else
                {
                    oLogin.NombreUsuario = "";
                    oLogin.Password = "";
                    oLogin.IdUsuario = 0;
                }

                //3-Se retorna el json al cliente.
                respuestaJSON = JsonConvert.SerializeObject(oLogin);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Error en AltaUsuario: " + ex.ToString());
            }
            return respuestaJSON;
        }

        private TransaccionInfo ClientAutorizador(Iso8583Message pmsgEntrada)
        {
            ILogger loggerTrx = null;
            string xmlFileNameFormatterISO = null;
            string remoteInterface = null;
            int remotePort = 0;
            TransaccionInfo oTranInfo = new TransaccionInfo();

            LogManager.LoggerFactory = new Log4NetLoggerFactory();
            LogManager.Renderer = new Renderer();
            loggerTrx = LogManager.GetLogger("root");

            xmlFileNameFormatterISO = ConfigurationManager.AppSettings["XmlFileNameFormatterISO"];//Seteo archivo de formato ISO8583
            remoteInterface = ConfigurationManager.AppSettings["RemoteInterface"];//Seteo IP remota
            remotePort = int.Parse(ConfigurationManager.AppSettings["RemotePort"]);//Seteo puerto remoto

            try
            {

                Console.WriteLine("#################### Inicio ClientAutorizador ####################");
                loggerTrx.Warn("#################### Inicio ClientAutorizador ####################");

                string response = "-1";
                Iso8583Message msgSalida = null;
                TcpClientChannel client;
                var pipeline = new Pipeline();
                pipeline.Push(new ReconnectionSink());
                pipeline.Push(new NboFrameLengthSink(2) { IncludeHeaderLength = false, MaxFrameLength = 1024 });
                pipeline.Push(new MessageFormatterSink(new Iso8583MessageFormatter((@"" + xmlFileNameFormatterISO)) { MessageHeaderFormatter = new StringMessageHeaderFormatter(new FixedLengthManager(10), new BcdDataEncoderFactory().GetInstance()) }));

                var ts = new TupleSpace<ReceiveDescriptor>();

                // Create a client peer to connect to remote system. The messages
                // will be matched using fields 41 and 11.
                client = new TcpClientChannel(pipeline, ts, new FieldsMessagesIdentifier(new[] { 11, 41 }))
                {
                    RemotePort = Convert.ToInt32(remotePort),
                    RemoteInterface = remoteInterface,
                    Name = "ClientAutorizador"
                };

                Console.WriteLine("Conectando con cliente RemoteInterface = " + remoteInterface + " RemotePort = " + remotePort);
                loggerTrx.Warn("Conectando con cliente RemoteInterface = " + remoteInterface + " RemotePort = " + remotePort);

                //Conecta al servidor
                ChannelRequestCtrl ctrl = client.Connect();
                ctrl.WaitCompletion();

                if (!ctrl.Successful)
                {
                    Console.WriteLine("No hay conexion: " + ctrl.Error);
                    loggerTrx.Warn("No hay conexion: " + ctrl.Error);
                    oTranInfo.Estado = TransaccionResultado.ErrorSistema;
                }

                if (client.IsConnected)
                {
                    Console.WriteLine("Conecto con cliente");
                    loggerTrx.Warn("Conecto con cliente");

                    SendRequestHandlerCtrl sndCtrl = client.SendExpectingResponse(pmsgEntrada, 15000, false, null);
                    sndCtrl.WaitCompletion(); // Wait send completion.

                    if (!sndCtrl.Successful)
                    {
                        Console.WriteLine("Error al enviar mensaje: " + sndCtrl.Error);
                        loggerTrx.Info("Error al enviar mensaje: " + sndCtrl.Error);
                        oTranInfo.Estado = TransaccionResultado.ErrorSistema;
                    }
                    sndCtrl.Request.WaitResponse();

                    if (sndCtrl.Request.IsExpired)
                    {
                        Console.WriteLine("Expiro tiempo de espera de respuesta.");
                        loggerTrx.Info("Expiro tiempo de espera de respuesta.");
                        oTranInfo.Estado = TransaccionResultado.Expirada;
                    }
                    else
                    {
                        msgSalida = sndCtrl.Request.ReceivedMessage as Iso8583Message;
                        Console.WriteLine("iMsg : " + msgSalida.ToString());
                        loggerTrx.Info("iMsg : " + msgSalida.ToString());
                    }
                }
                client.Disconnect();

                if (msgSalida != null)
                {
                    //Solo si el autorizador Online en CDE contesto OK
                    if (msgSalida.Fields.Contains(39))
                    {
                        response = msgSalida.Fields[39].ToString();

                        oTranInfo.CodigoTransaccion = msgSalida.Fields[39].ToString();
                        oTranInfo.MensajeTransaccion = msgSalida.Fields[63].ToString();

                        //Logica de respuesta
                        if (!response.Equals("00") && !response.Equals("25"))
                        {
                            oTranInfo.Estado = TransaccionResultado.Denegada;
                        }
                        else
                        {
                            oTranInfo.Estado = TransaccionResultado.Ok;
                            oTranInfo.CodigoAutorizacion = msgSalida.Fields[38].ToString();
                            oTranInfo.RRNTransaccion = msgSalida.Fields[37].ToString();
                        }

                    }
                }

                Console.WriteLine("Response: " + response);
                loggerTrx.Info("Response: " + response);

                Console.WriteLine("#################### Fin ClientAutorizador ####################");
                loggerTrx.Info("#################### Fin ClientAutorizador ####################");

                return oTranInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

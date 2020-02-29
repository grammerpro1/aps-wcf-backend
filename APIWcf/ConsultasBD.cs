using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIWcf
{
    public class ConsultasBD
    {

        public static void InsertarTransaccion(Transaccion xTransaccion)
        {
            SqlConnection conn = null;
            SqlCommand comm = null;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO Transacciones(IdTransaccion,Comercio,Pan,Sello,Monto,Cuotas,IdMoneda,EstadoTransaccion,FechaTransaccion,MTI,Processcod) VALUES(@IdTransaccion,@Comercio,@Pan,@Sello,@Monto,@Cuotas,@IdMoneda,@EstadoTransaccion,@FechaTransaccion,@MTI,@Processcod)";
                comm.Parameters.AddWithValue("IdTransaccion", xTransaccion.IdTransaccion);
                comm.Parameters.AddWithValue("Comercio", xTransaccion.Comercio);
                comm.Parameters.AddWithValue("Pan", xTransaccion.Pan);
                comm.Parameters.AddWithValue("Sello", xTransaccion.IdSello);
                comm.Parameters.AddWithValue("Monto", xTransaccion.Monto);
                comm.Parameters.AddWithValue("Cuotas", xTransaccion.Cuotas);
                comm.Parameters.AddWithValue("IdMoneda", xTransaccion.IdMoneda);
                comm.Parameters.AddWithValue("EstadoTransaccion", xTransaccion.EstadoTransaccion);
                comm.Parameters.AddWithValue("FechaTransaccion", xTransaccion.FechaTransaccion);
                comm.Parameters.AddWithValue("MTI", xTransaccion.MTI);
                comm.Parameters.AddWithValue("Processcod", xTransaccion.Processcod);

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
           

        }

        public static void InsertarComercio(Comercio xComercio)
        {
            SqlConnection conn = null;
            SqlCommand comm = null;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO Comercios(IdComercio,Nombre) VALUES(@IdComercio,@Nombre)";
                comm.Parameters.AddWithValue("IdComercio", xComercio.IdComercio);
                comm.Parameters.AddWithValue("Nombre", xComercio.Nombre);
                

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void InsertarTarjeta(Tarjeta xTarjeta)
        {
            SqlConnection conn = null;
            SqlCommand comm = null;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO Tarjetas(IdTarjeta,Nombre,Activa) VALUES(@IdTarjeta,@Nombre,@Activa)";
                comm.Parameters.AddWithValue("IdTarjeta", xTarjeta.IdTarjeta);
                comm.Parameters.AddWithValue("Nombre", xTarjeta.Nombre);
                comm.Parameters.AddWithValue("Activa", xTarjeta.Activa);

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        internal static long GenerarIdTarjetaCliente()
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            long idTarjetaCliente = 0;

            try
            {
                //Se obtiene el numerador
                idTarjetaCliente = ObtenerIdTarjetaCliente() + 1;

                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "UPDATE Numeradores SET IdTarjetaCliente = @IdTarjetaCliente";
                comm.Parameters.AddWithValue("IdTarjetaCliente", idTarjetaCliente);

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return idTarjetaCliente;
        }

        internal static void InsertarTarjetaCliente(TarjetaCliente xTarjetaCliente)
        {
            SqlConnection conn = null;
            SqlCommand comm = null;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO TarjetasClientes(IdTarjetaCliente,Proveedor,IdCliente,NumeroTarjeta,Expiracion,FechaCreacion,Activa,EstadoExpirada,IdTarjeta) VALUES(@IdTarjetaCliente,@Proveedor,@IdCliente,@NumeroTarjeta,@Expiracion,@FechaCreacion,@Activa,@EstadoExpirada,@IdTarjeta)";
                comm.Parameters.AddWithValue("IdTarjetaCliente", xTarjetaCliente.IdTarjetaCliente);
                comm.Parameters.AddWithValue("Proveedor", xTarjetaCliente.Proveedor);
                comm.Parameters.AddWithValue("IdCliente", xTarjetaCliente.IdCliente);
                comm.Parameters.AddWithValue("NumeroTarjeta", xTarjetaCliente.NumeroTarjeta);
                comm.Parameters.AddWithValue("Expiracion", xTarjetaCliente.Expiracion);
                comm.Parameters.AddWithValue("FechaCreacion", xTarjetaCliente.FechaCreacion);
                comm.Parameters.AddWithValue("Activa", xTarjetaCliente.Activa);
                comm.Parameters.AddWithValue("EstadoExpirada", xTarjetaCliente.EstadoExpirada);
                comm.Parameters.AddWithValue("IdTarjeta", xTarjetaCliente.IdTarjeta);

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static long ObtenerIdTarjetaCliente()
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader reader = null;
            int idTarjetaCliente = 0;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "SELECT IdTarjetaCliente FROM Numeradores";

                conn.Open();

                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    idTarjetaCliente = int.Parse(reader[0].ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();

            }

            return idTarjetaCliente;
        }

        public static int GenerarIdCliente()
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            int idCliente = 0;

            try
            {
                //Se obtiene el numerador
                idCliente = ObtenerNumeroCliente() + 1;

                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "UPDATE Numeradores SET IdCliente = @IdCliente";
                comm.Parameters.AddWithValue("IdCliente", idCliente);

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return idCliente;
        }

        public static void InsertarUsuario(Usuario xUsuario)
        {
            SqlConnection conn = null;
            SqlCommand comm = null;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO Clientes(IdCliente,PrimerApellido,PrimerNombre,Email,IdComercio,NombreUsuario,Password) VALUES(@IdCliente,@PrimerApellido,@PrimerNombre,@Email,@IdComercio,@NombreUsuario,@Password)";
                comm.Parameters.AddWithValue("IdCliente", xUsuario.IdUsuario);
                comm.Parameters.AddWithValue("PrimerApellido", xUsuario.PrimerApellido);
                comm.Parameters.AddWithValue("PrimerNombre", xUsuario.PrimerNombre);
                comm.Parameters.AddWithValue("Email", xUsuario.Email);
                comm.Parameters.AddWithValue("IdComercio", xUsuario.IdComercio);
                comm.Parameters.AddWithValue("NombreUsuario", xUsuario.NombreUsuario);
                comm.Parameters.AddWithValue("Password", xUsuario.Password);

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        private static int ObtenerNumeroCliente()
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader reader = null;
            int idCliente = 0;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "SELECT IdCliente FROM Numeradores";

                conn.Open();

                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    idCliente = int.Parse(reader[0].ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();

            }

            return idCliente;
        }

        public static long GenerarIdTransaccionInfo()
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            long idTransaccion = 0;

            try
            {
                //Se obtiene el numerador para la transaccionInfo
                idTransaccion = ObtenerNumeroTransaccionInfo() + 1;

                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "UPDATE Numeradores SET IdTransaccionInfo = @IdTransaccionInfo";
                comm.Parameters.AddWithValue("IdTransaccionInfo", idTransaccion);

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return idTransaccion;
        }

        public static long ObtenerNumeroTransaccionInfo()
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader reader = null;
            long idTransaccion = 0;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "SELECT IdTransaccionInfo FROM Numeradores";

                conn.Open();

                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    idTransaccion = long.Parse(reader[0].ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();

            }

            return idTransaccion;
        }

        public static void InsertarTransaccionInfo(Transaccion xTransaccion, TransaccionInfo xTranInfo)
        {
            SqlConnection conn = null;
            SqlCommand comm = null;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO TransaccionInfo(IdTransaccionInfo,IdCliente,Estado,CodigoTransaccion,MensajeTransaccion,CodigoAutorizacion,RRNTransaccion,IdTransaccion) VALUES(@IdTransaccionInfo,@IdCliente,@Estado,@CodigoTransaccion,@MensajeTransaccion,@CodigoAutorizacion,@RRNTransaccion,@IdTransaccion)";
                comm.Parameters.AddWithValue("IdTransaccionInfo", xTranInfo.IdTransaccionInfo);
                comm.Parameters.AddWithValue("IdCliente", xTranInfo.IdCliente);
                comm.Parameters.AddWithValue("Estado", xTranInfo.Estado);
                comm.Parameters.AddWithValue("CodigoTransaccion", xTranInfo.CodigoTransaccion);
                comm.Parameters.AddWithValue("MensajeTransaccion", xTranInfo.MensajeTransaccion);
                comm.Parameters.AddWithValue("CodigoAutorizacion", xTranInfo.CodigoAutorizacion);
                comm.Parameters.AddWithValue("RRNTransaccion", xTranInfo.RRNTransaccion);
                comm.Parameters.AddWithValue("IdTransaccion", xTransaccion.IdTransaccion);

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static int GenerarIdComercioTarjeta()
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            int idComercioTarjeta = 0;

            try
            {
                //Se obtiene el numerador
                idComercioTarjeta = ObtenerIdComercioTarjeta() + 1;

                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "UPDATE Numeradores SET IdComercioTarjeta = @IdComercioTarjeta";
                comm.Parameters.AddWithValue("IdComercioTarjeta", idComercioTarjeta);

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return idComercioTarjeta;
        }

        public static ArrayList ObtenerMPComercio(ConsultaMPComercioRequest xConsulta)
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader reader = null;
            ArrayList Lista = new ArrayList();

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "SELECT ComerciosTarjetas.IdComercioTarjeta," +
                    "                      ComerciosTarjetas.IdTarjeta," +
                    "                      ComerciosTarjetas.Metadata," +
                    "                      Tarjetas.Nombre " +
                    "               FROM ComerciosTarjetas, " +
                    "                    Tarjetas " +
                    "               WHERE ComerciosTarjetas.IdComercio = @IdComercio AND " +
                    "                     Tarjetas.IdTarjeta =  ComerciosTarjetas.IdTarjeta";
                comm.Parameters.AddWithValue("IdComercio", xConsulta.IdComercio);

                conn.Open();

                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    ComercioTarjeta oComTar = new ComercioTarjeta();
                    oComTar.IdComercioTarjeta = int.Parse(reader[0].ToString());
                    oComTar.IdComercio = xConsulta.IdComercio;
                    oComTar.IdTarjeta = int.Parse(reader[1].ToString());
                    oComTar.Metadata = reader[2].ToString();
                    oComTar.NombreTarjeta = reader[3].ToString();

                    Lista.Add(oComTar);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();

            }

            return Lista;
        }

        public static ArrayList ObtenerMPUsuario(ConsultaMPUsuarioRequest xConsulta)
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader reader = null;
            ArrayList Lista = new ArrayList();

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "SELECT TarjetasClientes.IdTarjetaCliente," +
                    "                      TarjetasClientes.Proveedor, " +
                    "                      TarjetasClientes.NumeroTarjeta, " +
                    "                      TarjetasClientes.Expiracion, " +
                    "                      TarjetasClientes.FechaCreacion, " +
                    "                      TarjetasClientes.Activa, " +
                    "                      TarjetasClientes.EstadoExpirada, " +
                    "                      TarjetasClientes.IdTarjeta " +
                    "               FROM TarjetasClientes " +
                    "               WHERE TarjetasClientes.IdCliente = @IdCliente";
                comm.Parameters.AddWithValue("IdCliente", xConsulta.IdCliente);

                conn.Open();

                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    TarjetaCliente oTarCli = new TarjetaCliente();
                    oTarCli.IdTarjetaCliente = int.Parse(reader[0].ToString());
                    oTarCli.Proveedor = reader[1].ToString();
                    oTarCli.IdCliente = xConsulta.IdCliente;
                    oTarCli.NumeroTarjeta = reader[2].ToString();
                    oTarCli.Expiracion = DateTime.Parse(reader[3].ToString());
                    oTarCli.FechaCreacion = DateTime.Parse(reader[4].ToString());
                    oTarCli.Activa = int.Parse(reader[5].ToString());
                    oTarCli.EstadoExpirada = int.Parse(reader[6].ToString());
                    oTarCli.IdTarjeta = int.Parse(reader[7].ToString());

                    Lista.Add(oTarCli);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();

            }

            return Lista;
        }

        public static int VerificarCredencialesUsuario(LoginRequest xLogin)
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader reader = null;
            int idCliente = 0;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "SELECT Clientes.IdCliente" +
                    "               FROM Clientes" +
                    "               WHERE Clientes.NombreUsuario = @NombreUsuario AND" +
                    "                     Clientes.Password = @Password";
                comm.Parameters.AddWithValue("NombreUsuario", xLogin.NombreUsuario);
                comm.Parameters.AddWithValue("Password", xLogin.Password);

                conn.Open();

                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    idCliente = int.Parse(reader[0].ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return idCliente;
        }

        public static void InsertarComercioTarjeta(ComercioTarjeta oComercioTarjeta)
        {
            SqlConnection conn = null;
            SqlCommand comm = null;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO ComerciosTarjetas(IdComercioTarjeta,IdComercio,IdTarjeta,Metadata) VALUES(@IdComercioTarjeta,@IdComercio,@IdTarjeta,@Metadata)";
                comm.Parameters.AddWithValue("IdComercioTarjeta", oComercioTarjeta.IdComercioTarjeta);
                comm.Parameters.AddWithValue("IdComercio", oComercioTarjeta.IdComercio);
                comm.Parameters.AddWithValue("IdTarjeta", oComercioTarjeta.IdTarjeta);
                comm.Parameters.AddWithValue("Metadata", oComercioTarjeta.Metadata);

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static int ObtenerIdComercioTarjeta()
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader reader = null;
            int idComercioTarjeta = 0;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "SELECT IdComercioTarjeta FROM Numeradores";

                conn.Open();

                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    idComercioTarjeta = int.Parse(reader[0].ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();

            }

            return idComercioTarjeta;
        }

        public static int GenerarIdTarjeta()
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            int idTarjeta = 0;

            try
            {
                //Se obtiene el numerador
                idTarjeta = ObtenerNumeroTarjeta() + 1;

                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "UPDATE Numeradores SET IdTarjeta = @IdTarjeta";
                comm.Parameters.AddWithValue("IdTarjeta", idTarjeta);

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return idTarjeta;
        }

        private static int ObtenerNumeroTarjeta()
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader reader = null;
            int idTarjeta = 0;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "SELECT IdTarjeta FROM Numeradores";

                conn.Open();

                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    idTarjeta = int.Parse(reader[0].ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();

            }

            return idTarjeta;
        }

        public static long GenerarIdComercio()
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            long idComercio = 0;

            try
            {
                //Se obtiene el numerador
                idComercio = ObtenerNumeroComercio() + 1;

                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "UPDATE Numeradores SET IdComercio = @IdComercio";
                comm.Parameters.AddWithValue("IdComercio", idComercio);

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return idComercio;
        }


        public static long GenerarIdTransaccion()
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            long idTransaccion = 0;

            try
            {
                //Se obtiene el numerador para la transaccion
                idTransaccion = ObtenerNumeroTransaccion() + 1;

                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "UPDATE Numeradores SET IdTransaccion = @IdTransaccion";
                comm.Parameters.AddWithValue("IdTransaccion", idTransaccion);
                
                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return idTransaccion;

        }

        public static long ObtenerNumeroTransaccion()
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader reader = null;
            long idTransaccion = 0;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "SELECT IdTransaccion FROM Numeradores";

                conn.Open();

                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    idTransaccion = long.Parse(reader[0].ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                
            }

            return idTransaccion;
        }

        private static long ObtenerNumeroComercio()
        {
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader reader = null;
            long idComercio = 0;

            try
            {
                conn = ConexionBD.ConectarBD();

                comm = conn.CreateCommand();
                comm.CommandText = "SELECT IdComercio FROM Numeradores";

                conn.Open();

                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    idComercio = long.Parse(reader[0].ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();

            }

            return idComercio;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace APIWcf
{
    public class ConexionBD
    {
        static SqlConnection conn;
        static SqlConnectionStringBuilder str;

        public static SqlConnection ConectarBD()
        {
            try
            {
                if (conn == null)
                {
                    
                    str = new SqlConnectionStringBuilder();
                    str.DataSource = ConfigurationManager.AppSettings["ServidorBD"];//ConfigurationManager.AppSettings[@"ServidorBD"];// "LENOVO-APA\\SQLEXPRESS"
                    //str.DataSource = "proyecto.cvaq0bogweup.us-east-2.rds.amazonaws.com";
                    str.InitialCatalog = "gateway";
                    str.Encrypt = true;
                    str.TrustServerCertificate = true;
                    str.ConnectTimeout = 30;
                    str.AsynchronousProcessing = true;
                    str.MultipleActiveResultSets = true;
                    str.IntegratedSecurity = false;
                    str.UserID = ConfigurationManager.AppSettings["UserID"]; //sa
                    str.Password = ConfigurationManager.AppSettings["ContraseñaBD"]; //19640328
                    //str.UserID = "proyecto";
                    //str.Password = "Ucu.ingenieria2019";

                    conn = new SqlConnection(str.ToString());
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return conn;
        }
    }
}
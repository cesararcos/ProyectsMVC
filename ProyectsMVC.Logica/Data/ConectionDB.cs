using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProyectsMVC.Logica.Data
{
    public class ConectionDB
    {

        private ConectionDB()
        {

        }

        //Singleton
        private static SqlConnection connection = null;


        /// <summary>
        /// METODO QUE CIERRA CONEXION
        /// </summary>
        public static void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO QUE ESTABLECE LA CONEXION
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            try
            {
                if (connection == null)
                {
                    string cnx = ConfigurationManager.ConnectionStrings["Cnx"].ToString();
                    connection = new SqlConnection(cnx);
                    connection.Open();
                }

                return connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

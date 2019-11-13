using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProyectsMVC.Logica.Services
{
    public class UpdateSaleDetails
    {
        private SqlConnection connetion = null;
        private SqlCommand command = null;
        private SqlDataAdapter dataAdapter = null;

        /// <summary>
        /// METODO QUE CREA LA ACTIVIDAD
        /// </summary>
        /// <param name="name">NOMBRE DE LA ACTIVIDAD</param>
        public void UpdateDetails(int idsale,
            int idsaledetails)
        {
            try
            {
                connetion = Data.ConectionDB.GetConnection();
                command = new SqlCommand("UpdateActivity", connetion);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@IdSale", idsale));
                command.Parameters.Add(new SqlParameter("@IdSaleDetails", idsaledetails));

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

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
        /// METODO QUE ACTUALIZAR SALEDETAILS
        /// </summary>
        /// <param name="idsale"></param>
        /// <param name="idsaledetails">ID DE SALES EN TABLA SALEDETAILS</param>
        public void UpdateDetails(int idsale,
            int idsaledetails)
        {
            try
            {
                connetion = Data.ConectionDB.GetConnection();
                command = new SqlCommand("UpdateSaleDetails", connetion);
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

        /// <summary>
        /// METODO PARA ACTUALIZAR SALES
        /// </summary>
        /// <param name="idsale"></param>
        /// <param name="idsaledetails">ID DE METHODPAYMENT EN TABLA SALES</param>
        public void UpdatemethodPayment(int? idmethodPayment,
            int idsales)
        {
            try
            {
                connetion = Data.ConectionDB.GetConnection();
                command = new SqlCommand("UpdateMethodPayment", connetion);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@IdmethodPayment", idmethodPayment));
                command.Parameters.Add(new SqlParameter("@Idsales", idsales));

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

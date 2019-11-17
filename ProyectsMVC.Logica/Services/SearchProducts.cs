using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Services
{
    public class SearchProducts
    {
        private SqlConnection connetion = null;
        private SqlCommand command = null;
        private SqlDataAdapter dataAdapter = null;

        public List<Models.DB.SearchProducts> GetSearchProducts(int? CategoryId, string prodName)
        {
            try
            {
                var listSearchProducts = new List<Models.DB.SearchProducts>();

                connetion = Data.ConectionDB.GetConnection();
                command = new SqlCommand("SearchProducts", connetion);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@CategoryId", CategoryId));
                command.Parameters.Add(new SqlParameter("@ProductName", prodName));

                DataSet result = new DataSet();
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);

                foreach (DataRow item in result.Tables[0].Rows)
                {
                    listSearchProducts.Add(new Models.DB.SearchProducts
                    {
                        prodId = Convert.ToInt32(item["prodId"]),
                        CategoryId = Convert.ToInt32(item["CategoryId"]),
                        CategoryName = (string)item["CategoryName"],
                        prodName = (string)item["prodName"],
                        Price = (double)item["Price"],
                        ShippingCost = (double)item["ShippingCost"],
                        Warranty = (string)item["Warranty"],
                        Description = (string)item["Description"],
                        Quantity = Convert.ToInt32(item["Quantity"]),
                        StateId = Convert.ToInt32(item["StateId"]),
                        StateName = (string)item["StateName"],
                        //CustomerId = Convert.ToInt32(item["CustomerId"]),  //SE COMENTA PORQUE AUN NO HAY CUSTOMER
                        Guid = (string)item["Guid"]
                    });
                }

                return listSearchProducts;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Models.DB.SearchProducts> GetSearchProductsAll()
        {
            try
            {
                var listSearchProducts = new List<Models.DB.SearchProducts>();

                connetion = Data.ConectionDB.GetConnection();
                command = new SqlCommand("SearchProductsAll", connetion);
                command.CommandType = CommandType.StoredProcedure;

                DataSet result = new DataSet();
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);

                foreach (DataRow item in result.Tables[0].Rows)
                {
                    listSearchProducts.Add(new Models.DB.SearchProducts
                    {
                        prodId = Convert.ToInt32(item["prodId"]),
                        CategoryId = Convert.ToInt32(item["CategoryId"]),
                        CategoryName = (string)item["CategoryName"],
                        prodName = (string)item["prodName"],
                        Price = (double)item["Price"],
                        ShippingCost = (double)item["ShippingCost"],
                        Warranty = (string)item["Warranty"],
                        Description = (string)item["Description"],
                        Quantity = Convert.ToInt32(item["Quantity"]),
                        StateId = Convert.ToInt32(item["StateId"]),
                        StateName = (string)item["StateName"],
                        //CustomerId = Convert.ToInt32(item["CustomerId"]),  //SE COMENTA PORQUE AUN NO HAY CUSTOMER
                        Guid = (string)item["Guid"]
                    });
                }

                return listSearchProducts;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

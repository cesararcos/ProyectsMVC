using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ProyectsMVC.Logica.Models.DB;

namespace ProyectsMVC.Logica.Services
{
    public class Login : Interfaces.ILogin
    {
        private SqlConnection connetion = null;
        private SqlCommand command = null;
        private SqlDataAdapter dataAdapter = null;


        public List<Models.DB.AspNetUsers> GetAspNetUsers()
        {
            try
            {
                var listLogin = new List<Models.DB.AspNetUsers>();

                connetion = Data.ConectionDB.GetConnection();
                command = new SqlCommand("GetUsers", connetion);
                command.CommandType = CommandType.StoredProcedure;

                DataSet result = new DataSet();
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);

                foreach (DataRow item in result.Tables[0].Rows)
                {
                    listLogin.Add(new Models.DB.AspNetUsers
                    {
                        //Id = (int)item["Id"],
                        //Email = (string)item["Email"],
                        //password = (string)item["Password"]
                    });
                }

                return listLogin;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StationaryManagement.Models;

namespace StationaryManagement.Gateway
{
    public class StationaryGateway
    {
        public string connectionString =
          WebConfigurationManager.ConnectionStrings["StationaryManagementConnection"].ConnectionString;

        public int SaveStationary(Stationary stationary)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO t_Stationary VALUES('" + stationary.Name + "','" + stationary.Price+"','"+stationary.Purpose+"','"+stationary.TypeId + "')";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int noOfRowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return noOfRowsAffected;
        }

        public List<Stationary> ViewSelectedStationary(int typeId)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT *FROM t_Stationary WHERE TypeId="+typeId;
            //string query = "select t_Stationary.Name,t_Stationary.Price,t_Stationary.Purpose,Sum(t_Stationary.Price) As Total_Price from t_Stationary join t_stationarType on t_Stationary.TypeId=t_stationarType.Id WHERE t_Stationary.TypeId=" +typeId + " Group By t_Stationary.Name,t_Stationary.Price,t_Stationary.Purpose";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Stationary> stationaries = new List<Stationary>();
            while (reader.Read())
            {
                Stationary stationary = new Stationary()
                {
                    Name = reader["Name"].ToString(),
                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                    Purpose = reader["Purpose"].ToString(),
                };
                stationaries.Add(stationary);
            }
            reader.Close();
            connection.Close();
            return stationaries;
        }

        public decimal GettotalPrice(int typeId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select Sum(t_Stationary.Price) As Total_Price from t_Stationary join t_stationarType on t_Stationary.TypeId=t_stationarType.Id WHERE t_Stationary.TypeId=" + typeId + " Group By t_Stationary.Price";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            decimal totalPrice = Convert.ToDecimal(command.ExecuteScalar());
            connection.Close();
            return totalPrice;
        }
    }
}
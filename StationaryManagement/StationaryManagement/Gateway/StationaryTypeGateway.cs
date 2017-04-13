using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StationaryManagement.Models;

namespace StationaryManagement.Gateway
{
    public class StationaryTypeGateway
    {
        public string connectionString =
           WebConfigurationManager.ConnectionStrings["StationaryManagementConnection"].ConnectionString;

        public List<StationaryType> ViewAllStationaryType()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT *FROM t_stationarType";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<StationaryType> types = new List<StationaryType>();
            while (reader.Read())
            {
                StationaryType type = new StationaryType()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString()
                };
                types.Add(type);
            }
            reader.Close();
            connection.Close();
            return types;
        } 
    }
}
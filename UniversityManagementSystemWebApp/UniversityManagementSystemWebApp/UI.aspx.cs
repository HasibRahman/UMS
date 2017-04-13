using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityManagementSystemWebApp
{
    public partial class UI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string regNo = regNoTextBox.Text;
            string connectionString =
                @"Server=PC-301-01\SQLEXPRESS;Database=UniversityManagementSystemDB;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Students VALUES('"+name+"','"+address+"','"+regNo+"')";

            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int message = command.ExecuteNonQuery();
            connection.Close();

            if (message>0)
            {
                messageLabel.Text = "Saved Successfully";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityManagementSystem.UI
{
    public partial class StudentEntryUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {

            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string regNo = regNoTextBox.Text;
            string phoneNumber = phoneNumberTextBox.Text;

            //1.connect to database
            string connectionString =
                @"Server=.\SQLEXPRESS; Database =UniversityManagementSystemDB; Integrated Security = true;";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;


            //2. write the query

            //                INSERT INTO Students VALUES('name','address','regNo','phoneNumber');

            string query = "INSERT INTO Students VALUES('"+name+"','"+address+"','"+regNo+"','"+phoneNumber+"')";

            //3. Execute the query using the connection

            SqlCommand command = new SqlCommand(query,connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            
            //4. Show Result (in this case -> saved or not)

            if (rowAffected > 0)
            {
                messageLabel.Text = "Saved Successfully!";
            }
            else
            {
                messageLabel.Text = "Insertion failed!";
            }

        }
    }
}
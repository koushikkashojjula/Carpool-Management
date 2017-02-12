using System;
using MySql.Data.MySqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace CarpoolManagementSystem
{
    public partial class Default : System.Web.UI.Page
    {
        MySqlConnection mySqlConnection;
        MySqlCommand mySqlCommand;
        MySqlDataReader mySqlDataReader;
        String queryString, name;

        public void Page_Load(object sender, EventArgs e)
        {
            String connString = "server=localhost;user id=root;password=password;database=test;persistsecurityinfo=True";
            mySqlConnection = new MySqlConnection(connString);
        }

        public void SubmitNameMethod(object sender, EventArgs e)
        {
            try
            {
                mySqlConnection.Open();
                queryString = "INSERT INTO `test`.`test` (`Name`) VALUES ('" + NameTextBox.Text + "');";
                mySqlCommand = new MySqlCommand(queryString, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                Response.Write("<script>alert('Name Entered successfully');</script>");

                mySqlConnection.Open();
                queryString = "SELECT Name FROM `test`.`test` order by Number desc limit 1";
                mySqlCommand = new MySqlCommand(queryString, mySqlConnection);
                mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                        name = mySqlDataReader.GetString(0);
                    }
                    name = mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("Name"));
                }
                mySqlConnection.Close();
                this.NameLabel.Text = "Hello " + name;
                
            }
            catch
            {
                Response.Write("<script>alert('Failed to enter in database');</script>");
            }
        }
    }
}
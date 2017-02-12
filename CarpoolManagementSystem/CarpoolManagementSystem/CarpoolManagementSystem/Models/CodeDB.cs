using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;


namespace LoginSignup.Models
{
    public class CodeDB
    {
        //variable connection
        private SqlConnection con = null;

        //open connection
        public bool Open(string Connection = "DefaultConnection")
        {
            try
            {
                try
                {
                    con = new SqlConnection(@WebConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                }
                catch (NullReferenceException)
                {
                    return false;
                }
                if (con != null)
                {
                    if (con.State.ToString() != "Open")
                    {
                        con.Open();
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        //close connection
        public bool Close(string Connection = "DefaultConnection")
        {
            try
            {
                con.Close();
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public int ToInt(object s)
        {
            try
            {
                return Int32.Parse(s.ToString());
            }
            catch
            {
                return 0;
            }
        }

        //Insert into DB 
        public int DataInsert(string sql)
        {
            int iLastID = 1;
            string szQuery = sql + ";SELECT @@Identity;";
            try
            {
                if (con.State.ToString() == "Open")
                {
                    SqlCommand cmd = new SqlCommand(szQuery, con);

                    iLastID = ToInt(cmd.ExecuteReader());// */ExecuteNonQuery();

                    //iLastID = this.ToInt(cmd.ExecuteScalar());                    
                }
                return this.ToInt(iLastID);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public SqlDataReader DataRetrieve(string sql)
        {
            string szQuery = sql + ";SELECT @@Identity;";
            SqlDataReader reader=null;
            try
            {
                if (con.State.ToString() == "Open")
                {
                    SqlCommand cmd = new SqlCommand(szQuery, con);

                    reader = cmd.ExecuteReader();// */ExecuteNonQuery();

                    //iLastID = this.ToInt(cmd.ExecuteScalar());
                }
                return reader;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
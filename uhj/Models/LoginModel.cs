using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace poe.Models
{
    public class LoginModel 
    {
    
            public static string con_string = "Server=tcp:cldv-server-sql.database.windows.net,1433;Initial Catalog=cldv-DB;Persist Security Info=False;User ID=stephane-kib;Password=CTMMonecole1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";


        public int SelectUser(string UserName, string UserEmail, string UserPassword)
            {
                int UserID = -1; // Default value if user is not found
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string sql = "SELECT UserID FROM UserTable WHERE UserEmail = @UserEmail AND UserName = @UserName AND UserPassword = @UserPassword";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@UserEmail", UserEmail);
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@UserPassword", UserPassword);
                try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            UserID = Convert.ToInt32(result);

                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or handle it appropriately
                        // For now, rethrow the exception
                        throw ex;
                    }

                }
            
            return UserID;
            }

        }
    }



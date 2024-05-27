using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

using System.Xml.Linq;
namespace poe.Models
{
    public class ContactTable 
    {

            public static string con_string = "Server=tcp:cldv-server-sql.database.windows.net,1433;Initial Catalog=cldv-DB;Persist Security Info=False;User ID=stephane-kib;Password=CTMMonecole1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";



            public static SqlConnection con = new SqlConnection(con_string);

            public string FirstName { get; set; }

            public string Email{ get; set; }

            public string Country { get; set; }

            public string Subject { get; set; }

            public int insert_User_caontact(ContactTable m)
            {

                try
                {
                    string sql = "INSERT INTO ContactTable (FirstName, Email, Country,Subject ) VALUES (@FirstName, @Email, @Country,@Subject)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@FirstName", m.FirstName);
                    cmd.Parameters.AddWithValue("@Email", m.Email);
                    cmd.Parameters.AddWithValue("@Country", m.Country);
                    cmd.Parameters.AddWithValue("@Subject", m.Subject);
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    // For now, rethrow the exception
                    throw ex;
                }


            }

        }
    }



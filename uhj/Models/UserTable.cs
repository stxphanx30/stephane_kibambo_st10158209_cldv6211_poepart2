using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

using System.Xml.Linq;
namespace poe.Models
{
    public class UserTable 
    {

        public static string con_string = "Server=tcp:cldv-server-sql.database.windows.net,1433;Initial Catalog=cldv-DB;Persist Security Info=False;User ID=stephane-kib;Password=CTMMonecole1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";



        public static SqlConnection con = new SqlConnection(con_string);

        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public int insert_User(UserTable m)
        {

            try
            {
                string sql = "INSERT INTO UserTable (UserName, UserSurname, UserEmail,UserPassword) VALUES (@UserName, @UserSurname, @UserEmail,@UserPassword)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UserName", m.UserName);
                cmd.Parameters.AddWithValue("@UserSurname", m.UserSurname);
                cmd.Parameters.AddWithValue("@UserEmail", m.UserEmail);
                cmd.Parameters.AddWithValue("@UserPassword", m.UserPassword);
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

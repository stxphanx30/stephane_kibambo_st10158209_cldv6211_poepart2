using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace poe.Models
{
    public class productTable
    {
        private static string con_string = "Server=tcp:cldv-server-sql.database.windows.net,1433;Initial Catalog=cldv-DB;Persist Security Info=False;User ID=stephane-kib;Password=CTMMonecole1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public int ProductAvailability { get; set; }

        public int InsertProduct(productTable product)
        {
            try
            {
                string sql = "INSERT INTO ProductTable (ProductName, ProductPrice, ProductCategory, ProductAvailability) VALUES (@ProductName, @ProductPrice, @ProductCategory, @ProductAvailability)";

                using (SqlConnection con = new SqlConnection(con_string))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                        cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                        cmd.Parameters.AddWithValue("@ProductCategory", product.ProductCategory);
                        cmd.Parameters.AddWithValue("@ProductAvailability", product.ProductAvailability);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                        return rowsAffected;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception with additional context
                throw new Exception("An error occurred while inserting the product.", ex);
            }
        }

        public static List<productTable> GetAllProducts()
        {
            List<productTable> products = new List<productTable>();

            string sql = "SELECT * FROM ProductTable";

            try
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                productTable product = new productTable
                                {
                                    ProductID = Convert.ToInt32(rdr["ProductID"]),
                                    ProductName = rdr["ProductName"].ToString(),
                                    ProductPrice = Convert.ToDecimal(rdr["ProductPrice"]),
                                    ProductCategory = rdr["ProductCategory"].ToString(),
                                    ProductAvailability = Convert.ToInt32(rdr["ProductAvailability"]),
                                };

                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception with additional context
                throw new Exception("An error occurred while retrieving products.", ex);
            }

            return products;
        }
    }
}
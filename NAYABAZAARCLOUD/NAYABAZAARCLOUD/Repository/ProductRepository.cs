using NAYABAZAARCLOUD.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAYABAZAARCLOUD.Services
{
    public class ProductRepository
    {
        private static string db_source = "nayabazaar.database.windows.net";
        private static string db_user = "Arslaan123";
        private static string db_password = "123Arslaank@";
        private static string db_database = "nayabazaar";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Products> GetProducts()
        {
            SqlConnection conn = GetConnection();

            List<Products> products_lst = new List<Products>();

            string statement = "SELECT * FROM products";

            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Products product = new Products()
                    {
                        ProductName = reader.GetString(0),
                        Price = reader.GetInt32(1)

                    };
                    products_lst.Add(product);
                }

            }
            conn.Close();
            return products_lst;
        }
    }
}
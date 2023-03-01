using Microsoft.Extensions.Configuration;
using NAYABAZAARCLOUD.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAYABAZAARCLOUD.Services
{
    public class ProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        private SqlConnection GetConnection()
        {
           
            return new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
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
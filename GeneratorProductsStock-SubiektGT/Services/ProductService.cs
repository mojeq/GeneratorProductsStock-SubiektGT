using GeneratorProductsStock_SubiektGT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace GeneratorProductsStock_SubiektGT.Services
{
    public static class ProductService
    {
        public static List<Product> GetAllProducts()
        {
            int idGroupSubiekt;
            ProductsList productList = new ProductsList();
            SubiektConnectionData sqlConnection = new SubiektConnectionData();

            SqlConnection connection = new SqlConnection(@sqlConnection.SubiektSqlConnection);
            connection.Open();
            SqlCommand commandSQL = connection.CreateCommand();
            commandSQL.CommandText = "SELECT st_TowId, st_Stan, tw_Symbol, tw_IdGrupa FROM tw_Stan INNER JOIN tw__Towar ON tw__Towar.tw_Id=tw_Stan.st_TowId WHERE tw__Towar.tw_IdGrupa IN ('36', '41', '50', '64', '18')";

            using (SqlDataReader reader = commandSQL.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader["tw_IdGrupa"] == DBNull.Value)
                    {
                        idGroupSubiekt = 0;
                    }
                    else
                    {
                        idGroupSubiekt = Convert.ToInt16(reader["tw_IdGrupa"]);
                    }
                    Product product = new Product
                    {
                        IdSubiekt = Convert.ToInt16(reader["st_TowId"]),
                        Stock = Convert.ToInt16(reader["st_Stan"]),
                        ProductSymbol = Convert.ToString(reader["tw_Symbol"]),
                        IdGroupSubiekt = idGroupSubiekt,
                    };
                    productList.Products.Add(product);
                };
            };

            return productList.Products;
        }

        public static void SaveProductsListAsJsonFile(List<Product> productsList)
        {
            string jsonProductsList = JsonConvert.SerializeObject(productsList);

            File.WriteAllText(@"d:\ListaSubiekt.json", jsonProductsList);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorProductsStock_SubiektGT.Models
{
    public class SubiektConnectionData
    {
        public string SubiektSqlConnection { get; set; }
        public SubiektConnectionData()
        {
            SubiektSqlConnection = "Data source=LAPTOP-6BMBVA7S\\SQLEXPRESS; database =Terra; Trusted_Connection=True;";
        }
    }
}

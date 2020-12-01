using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorProductsStock_SubiektGT.Models
{
    public class Product
    {
        public int IdSubiekt { get; set; }
        public int Stock { get; set; }
        public string ProductSymbol { get; set; }
        public int IdGroupSubiekt { get; set; }
    }
}

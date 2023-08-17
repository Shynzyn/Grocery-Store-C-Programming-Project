using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class ProductWrapper
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
        public double TotalSum { get; set; }

        public ProductWrapper(Product product, int amount)
        {
            Product = product;
            Amount = amount;
        }
    }
}
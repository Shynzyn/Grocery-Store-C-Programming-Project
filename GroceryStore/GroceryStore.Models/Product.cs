using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Constants;

namespace GroceryStore.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        public Product(string name, string category, double price, int amount = 1)
        {
            Name = name;
            Category = category;
            Price = price;
            Amount = amount;
        }

        public string GetProductInfo()
        {
            double result = Price * Amount;
            return $"({Category}) {Name} ${Price.ToString("0.##")} - {Amount}x - ${result.ToString("0.##")}";
        }
    }
}

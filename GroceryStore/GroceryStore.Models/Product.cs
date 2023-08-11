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
        public ProductCategories.Category Category { get; set; }
        public double Price { get; set; }

        public int Amount { get; set; }

        public Product(string name, ProductCategories.Category category, double price, int amount = 1)
        {
            Name = name;
            Category = category;
            Price = price;
            Amount = amount;
        }

        public string GetProductInfo()
        {
            string categoryName = GroceryStore.Constants.ProductCategories.GetCategoryName(Category);
            double result = Price * Amount;
            return $"({categoryName}) {Name} ${Price.ToString("0.##")} - {Amount}x - ${result.ToString("0.##")}";
        }
    }
}

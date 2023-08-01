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

        public Product(string name, ProductCategories.Category category,  double price)
        {
            Name = name;
            Category = category;
            Price = price;
        }
    }
}

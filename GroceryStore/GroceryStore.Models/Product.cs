using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Constants;

namespace GroceryStore.Models
{
    public abstract class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        protected DateTime ExpirationDate { get; private set; } = DateTime.Now.AddDays(1);
        protected int ExpirationDays { get; }

        protected Product(string name, double price, int expirationDays)
        {
            Name = name;
            Price = price;
            ExpirationDays = expirationDays;
            ExpirationDate = DateTime.Now.AddDays(expirationDays);
        }

        public override string ToString()
        {
            return
                $"({Category}) {Name} ${Price:0.##}, Exp. {ExpirationDate:dd.MM.yy}";
        }
    }
}
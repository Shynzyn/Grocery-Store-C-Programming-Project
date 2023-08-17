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
        protected DateTime _expirationDate = DateTime.Now;
        public string Name { get; set; }
        public string Category { get; protected set; }
        public double Price { get; set; }
        public abstract int ExpirationDays { get; protected set; }

        public DateTime ExpirationDate
        {
            get => _expirationDate;
            protected set => _expirationDate.AddDays(ExpirationDays);
        }

        protected Product(string name, string category, double price)
        {
            Name = name;
            Category = category;
            Price = price;
        }

        public override string ToString()
        {
            return
                $"({Category}) {Name} ${Price.ToString("0.##")}, Exp. {ExpirationDate.ToString("dd.MM.yy")}";
        }
    }
}
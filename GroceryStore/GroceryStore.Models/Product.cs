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
        public int Amount { get; set; }
        public abstract int ExpirationDays { get; protected set; }

        public DateTime ExpirationDate
        {
            get => _expirationDate;
            protected set => _expirationDate.AddDays(ExpirationDays);
        }

        protected Product(string name, string category, double price, int amount)
        {
            Name = name;
            Category = category;
            Price = price;
            Amount = amount;
        }

        public override string ToString()
        {
            double result = Price * Amount;
            return
                $"({Category}) {Name} ${Price.ToString("0.##")}, Exp. {ExpirationDate.ToString("dd.MM.yy")} - {Amount}x - ${result.ToString("0.##")}";
        }
    }
}
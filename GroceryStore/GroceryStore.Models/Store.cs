using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class Store
    {
        public Customer[] Customers = new Customer[100];
        private int customerCount = 0;
        public Product[] Products = new Product[100];
        public void AddCustomer(string firstName, string lastName, int age, char sex, bool hasDiscountCard, float personalDiscount= 0.0f)
        {
            if (customerCount >= Customers.Length)
            {
                Array.Resize(ref Customers, Customers.Length * 2);
            }
            Customer newCustomer = new Customer(firstName, lastName, age, sex, hasDiscountCard, personalDiscount);
            Customers[customerCount] = newCustomer;
            customerCount++;
        }
    }
}

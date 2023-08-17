using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using util = GroceryStore.Utils.Utility;

namespace GroceryStore.Models

{
    public class Store
    {
        private int _customerCount = 0;
        public Customer[] Customers = new Customer[0];

        public void AddCustomer(string firstName, string lastName, int age, char sex, bool hasDiscountCard,
            float personalDiscount = 0.05f)
        {
            if (_customerCount >= Customers.Length)
            {
                Array.Resize(ref Customers, _customerCount + 1);
            }

            Customer newCustomer = new Customer(firstName, lastName, age, sex, hasDiscountCard, personalDiscount);
            Customers[_customerCount] = newCustomer;
            _customerCount++;
        }

        public void AddCustomer(Customer customer)
        {
            if (_customerCount >= Customers.Length)
            {
                Array.Resize(ref Customers, _customerCount + 1);
            }

            Customers[_customerCount] = customer;
            _customerCount++;
        }

        public void PrintCustomersInformation()
        {
            if (Customers.Length <= 0)
            {
                Console.WriteLine("Store is empty");
            }
            else
            {
                string header = new string('-', 170) + "\n";
                string headerInfo =
                    $"| {util.CenterAlign("Full Name", 30)} | {util.CenterAlign("Age", 3)} | {util.CenterAlign("Sex", 5)} |" +
                    $" {util.CenterAlign("Has Discount Card", 5)} | {util.CenterAlign("Personal Discount", 8)} | {util.CenterAlign("Cart", 79)} |\n";

                string customerString = "";
                int counter = 0;
                double result = 0;
                string customerStringEnding = "";
                double totalSum = 0;

                foreach (var customer in Customers)
                {
                    if (customer.Cart.Length <= 0)
                    {
                    }
                    else
                    {
                        foreach (var cartElement in customer.Cart)
                        {
                            customerString +=
                                $"{customer.ToString()}{cartElement.Product.ToString()} - {cartElement.Amount:0.##}x - {cartElement.Product.Price:0.##}$ - {cartElement.Amount * cartElement.Product.Price:0.##}$\n";
                        }
                    }
                }

                Console.WriteLine(header + headerInfo + customerString);
            }
        }
    }
}
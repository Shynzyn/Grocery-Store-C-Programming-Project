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
    public static class Store
    {
        public static Customer[] Customers = new Customer[0];

        public static void AddCustomer(string firstName, string lastName, int age, char sex, bool hasDiscountCard,
            float personalDiscount = 0.05f)
        {
            Customer newCustomer = new Customer(firstName, lastName, age, sex, hasDiscountCard, personalDiscount);
            Array.Resize(ref Customers, Customers.Length + 1);
            Customers[Customers.Length - 1] = newCustomer;
        }

        public static void AddCustomer(Customer customer)
        {
            Array.Resize(ref Customers, Customers.Length + 1);
            Customers[Customers.Length - 1] = customer;
        }

        public static void PrintCustomersInformation()
        {
            if (Customers.Length <= 0)
            {
                Console.WriteLine("Store is empty");
            }
            else
            {
                string header = new string('-', 180) + "\n";
                string headerInfo =
                    $"| {util.CenterAlign("Full Name", 30)} | {util.CenterAlign("Age", 3)} | {util.CenterAlign("Sex", 5)} |" +
                    $" {util.CenterAlign("Has Discount Card", 5)} | {util.CenterAlign("Personal Discount", 8)} | {util.CenterAlign("Cart", 89)} |\n";
                string emptyLine =
                    $"|{util.CenterAlign("", 32)}|{util.CenterAlign("", 5)}|{util.CenterAlign("", 7)}|{util.CenterAlign("", 19)}|{util.CenterAlign("", 19)}|";
                Console.Write(header + headerInfo + header);
                foreach (var customer in Customers)
                {
                    string cartString = "";
                    double sum = 0;
                    string card = (customer.hasDiscountCard) ? "YES" : "NO";
                    string info =
                        $"| {util.CenterAlign(customer.FullName, 30)} | {util.CenterAlign(customer.Age.ToString(), 3)} | {util.CenterAlign(customer.Sex.ToString(), 5)} |" +
                        $" {util.CenterAlign(card, 17)} | {util.CenterAlign((customer.PersonalDiscount * 100) + "%", 18)}|";
                    if (customer.Cart.Length <= 0)
                    {
                        string emptyCart = "EMPTY";
                        info =
                            $"| {util.CenterAlign(customer.FullName, 30)} | {util.CenterAlign(customer.Age.ToString(), 3)} | {util.CenterAlign(customer.Sex.ToString(), 5)} |" +
                            $" {util.CenterAlign(card, 17)} | {util.CenterAlign((customer.PersonalDiscount * 100) + "%", 18)}| {util.CenterAlign(emptyCart, 90)}|\n";
                        Console.Write(info + header);
                    }
                    else
                    {
                        foreach (var cartElement in customer.Cart)
                        {
                            sum += (cartElement.Amount * cartElement.Product.Price);
                            cartString +=
                                $" {cartElement.Product} - {cartElement.Amount:0.##}x - {cartElement.Amount * cartElement.Product.Price:0.##}$"
                                    .PadRight(91) + $"|\n{emptyLine}";
                        }

                        string total =
                            $" TOTAL = ${sum:0.00} - DISCOUNT - {customer.PersonalDiscount * 100}% - ${(sum - (sum * customer.PersonalDiscount)):0.00}";
                        total = $"{total,-91}|\n";

                        Console.Write(info + cartString + total + header);
                    }
                }
            }
        }
    }
}
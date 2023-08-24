using util = GroceryStore.Utils.Utility;

namespace GroceryStore.Models;

public static class Store
{
    public static Customer[] Customers = Array.Empty<Customer>();

    public static void AddCustomer(string firstName, string lastName, int age, char sex, bool hasDiscountCard,
        float personalDiscount = 0.05f)
    {
        var newCustomer = new Customer(firstName, lastName, age, sex, hasDiscountCard, personalDiscount);
        Array.Resize(ref Customers, Customers.Length + 1);
        Customers[^1] = newCustomer;
    }

    public static void AddCustomer(Customer customer)
    {
        Array.Resize(ref Customers, Customers.Length + 1);
        Customers[^1] = customer;
    }

    public static void PrintCustomersInformation()
    {
        var header = new string('-', 180) + "\n";
        if (Customers.Length <= 0)
        {
            Console.WriteLine("Store is empty");
        }
        else
        {
            var headerInfo = $"| {util.CenterAlign("Full Name", 30)} | {util.CenterAlign("Age", 3)} | {util.CenterAlign("Sex", 5)} |" +
                             $" {util.CenterAlign("Has Discount Card", 5)} | {util.CenterAlign("Personal Discount", 8)} | {util.CenterAlign("Cart", 89)} |\n";
            var emptyLine = $"|{util.CenterAlign("", 32)}|{util.CenterAlign("", 5)}|{util.CenterAlign("", 7)}|{util.CenterAlign("", 19)}|{util.CenterAlign("", 19)}|";
            Console.Write(header + headerInfo);
            foreach (var customer in Customers)
            {
                Console.WriteLine(customer);
            }
        }

        Console.WriteLine(header);
    }
}
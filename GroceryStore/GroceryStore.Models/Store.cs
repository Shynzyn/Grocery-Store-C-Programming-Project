using util = GroceryStore.Utils.Utility;

namespace GroceryStore.Models;

public static class Store
{
    public static Dictionary<string, Customer> Customers = new();

    public static void AddCustomer(string firstName, string lastName, int age, char sex, bool hasDiscountCard,
        float personalDiscount = 0.05f)
    {
        Customers[firstName + " " + lastName] = new Customer(firstName, lastName, age, sex, hasDiscountCard, personalDiscount);
    }

    public static void AddCustomer(Customer customer)
    {
        Customers[customer.FullName] = customer;
    }

    public static void PrintCustomersInformation()
    {
        var header = new string('-', 180) + "\n";
        if (Customers.Count <= 0)
        {
            Console.WriteLine("Store is empty");
        }
        else
        {
            var headerInfo = $"| {util.CenterAlign("Full Name", 30)} | {util.CenterAlign("Age", 3)} | {util.CenterAlign("Sex", 5)} |" +
                             $" {util.CenterAlign("Has Discount Card", 5)} | {util.CenterAlign("Personal Discount", 8)} | {util.CenterAlign("Cart", 89)} |\n";
            var emptyLine = $"|{util.CenterAlign("", 32)}|{util.CenterAlign("", 5)}|{util.CenterAlign("", 7)}|{util.CenterAlign("", 19)}|{util.CenterAlign("", 19)}|";
            var customerStrings = Customers.Select(customer => customer.Value);
            var allCustomerStrings = string.Join("\n", customerStrings);

            Console.Write(header + headerInfo + allCustomerStrings + "\n");
        }

        Console.WriteLine(header);
    }
}
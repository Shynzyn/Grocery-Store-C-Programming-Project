using GroceryStore.Core.Helpers;
using GroceryStore.Models.Products;
using Newtonsoft.Json;
using util = GroceryStore.Utils.Utility;

namespace GroceryStore.Models;

public static class Store
{
    private static JsonSerializerSettings customSettings = new JsonSerializerSettings
    {
        Formatting = Formatting.Indented,
        Converters = { new ProductConverter() }
    };

    private static List<Customer> _customers = JsonHelper.LoadFromJson<Customer>("customers.json", customSettings).ToList();

    private static List<Product> _products = JsonHelper.LoadFromJson<Product>("products.json", customSettings).ToList();

    public static void AddCustomer(Customer customer)
    {
        _customers.AddCustomer(customer);
    }

    public static void AddProduct(Product product)
    {
        _products.AddProduct(product);
    }

    public static void PrintCustomersInformation()
    {
        var header = new string('-', 180) + "\n";
        if (_customers.Count <= 0)
        {
            Console.WriteLine("Store is empty");
        }
        else
        {
            var headerInfo = $"| {util.CenterAlign("Full Name", 30)} | {util.CenterAlign("Age", 3)} | {util.CenterAlign("Sex", 5)} |" +
                             $" {util.CenterAlign("Has Discount Card", 5)} | {util.CenterAlign("Personal Discount", 8)} | {util.CenterAlign("Cart", 89)} |\n";
            var emptyLine = $"|{util.CenterAlign("", 32)}|{util.CenterAlign("", 5)}|{util.CenterAlign("", 7)}|{util.CenterAlign("", 19)}|{util.CenterAlign("", 19)}|";
            var customerStrings = _customers.Select(customer => customer);
            var allCustomerStrings = string.Join("\n", customerStrings);

            Console.Write(header + headerInfo + allCustomerStrings + "\n");
        }

        Console.WriteLine(header);
    }
}
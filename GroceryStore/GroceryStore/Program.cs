using GroceryStore.Core.Helpers;
using GroceryStore.Models;
using GroceryStore.Models.Products;
using Newtonsoft.Json;

// Customers
var john = new Customer("John", "Doe", 22, 'm', true, 0.02f);
var sam = new Customer("Sam", "Brooks", 67, 'f', true, 0.12f);
var alois = new Customer("Alois", "Winter", 15, 'm', false);
var ann = new Customer("Ann", "Siemens", 44, 'f', false, 0.09f);
var peter = new Customer("Peter", "Parker", 9, 'm', false);

// Products
var cocaCola = new Drink("Coca-Cola", 1.12f, 1);
var tomatoes = new FruitsAndVegetables("Tomatoes", 0.99f, 0.5f);
var laysCheese = new Snacks("Lay's Cheese", 2.49f);
var norwayHerring = new Fish("Norway Herring", 4.55f);
var chickenNuggets = new Meat("Chicken Nuggets", 4.99);
var aperol = new Drink("Aperol", 9.99, 0.75f, true);

//cust4.UpdateDiscountCard(false);
//cust1.ChangeCustomerName("John", "Claus");

// Assigning Customers to the store

Store.AddCustomer(john);
Store.AddCustomer(sam);
Store.AddCustomer(alois);
Store.AddCustomer(ann);
Store.AddCustomer(peter);

Store.Customers["John Doe"].AddProductToCart(cocaCola, 2);
Store.Customers["John Doe"].AddProductToCart(norwayHerring);
Store.Customers["John Doe"].AddProductToCart(tomatoes, 7);

Store.Customers["Sam Brooks"].AddProductToCart(chickenNuggets);

Store.Customers["Alois Winter"].AddProductToCart(tomatoes, 3);

Store.Customers["Ann Siemens"].AddProductToCart(aperol);


Store.Customers["Peter Parker"].AddProductToCart(laysCheese, 5);
Store.Customers["Peter Parker"].AddProductToCart(cocaCola, 2);
Console.WriteLine(tomatoes);
Console.WriteLine(laysCheese);


Store.Customers["Peter Parker"].AddProductToCart(aperol);
Store.PrintCustomersInformation();

Console.WriteLine();

JsonHelper.SaveToJson(Store.Customers["John Doe"], "customers.json");


var settings = new JsonSerializerSettings
{
    Formatting = Formatting.Indented,
    Converters = { new ProductConverter() } // Add the custom converter
};
var customer = JsonHelper.LoadFromJson<Customer>("customers.json", settings);


Console.WriteLine(customer.Age);
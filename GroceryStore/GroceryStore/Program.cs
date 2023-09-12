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

Store.AddProduct(cocaCola);
Store.AddProduct(tomatoes);
Store.AddProduct(laysCheese);
Store.AddProduct(norwayHerring);
Store.AddProduct(chickenNuggets);
Store.AddProduct(aperol);

// Assigning Customers to the store

john.AddProductToCart(cocaCola, 2);
john.AddProductToCart(norwayHerring);
john.AddProductToCart(tomatoes, 7);

sam.AddProductToCart(chickenNuggets);

alois.AddProductToCart(tomatoes, 3);

ann.AddProductToCart(aperol);
peter.AddProductToCart(laysCheese, 5);
peter.AddProductToCart(cocaCola, 2);
peter.AddProductToCart(aperol);

Store.AddCustomer(john);
Store.AddCustomer(sam);
Store.AddCustomer(alois);
Store.AddCustomer(ann);
Store.AddCustomer(peter);
Store.PrintCustomersInformation();

Console.WriteLine();
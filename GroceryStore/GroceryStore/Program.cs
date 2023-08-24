using GroceryStore.Models;
using GroceryStore.Models.Products;

// Customers
var cust1 = new Customer("John", "Doe", 22, 'm', true, 0.02f);
var cust2 = new Customer("Sam", "Brooks", 67, 'f', true, 0.12f);
var cust3 = new Customer("Alois", "Winter", 15, 'm', false);
var cust4 = new Customer("Ann", "Siemens", 44, 'f', false, 0.09f);
var cust5 = new Customer("Peter", "Parker", 9, 'm', false);

// Products

var prod1 = new Drink("Coca-Cola", 1.12f, 1);
var prod2 = new FruitsAndVegetables("Tomatoes", 0.99f, 0.5f);
var prod3 = new Snacks("Lay's Cheese", 2.49f);
var prod4 = new Fish("Norway Herring", 4.55f);
var prod5 = new Meat("Chicken Nuggets", 4.99);
var prod6 = new Drink("Aperol", 9.99, 0.75f);

//cust4.UpdateDiscountCard(false);
//cust1.ChangeCustomerName("John", "Claus");

// Assigning Customers to the store

Store.AddCustomer(cust1);
Store.AddCustomer(cust2);
Store.AddCustomer(cust3);
Store.AddCustomer(cust4);
Store.AddCustomer(cust5);

Store.Customers[0].AddProductToCart(prod1, 2);
Store.Customers[0].AddProductToCart(prod4, 1);
Store.Customers[0].AddProductToCart(prod2, 7);

Store.Customers[2].AddProductToCart(prod2, 3);

Store.Customers[3].AddProductToCart(prod6, 1);

Store.Customers[1].AddProductToCart(prod5, 1);

Store.Customers[4].AddProductToCart(prod3, 5);
Store.Customers[4].AddProductToCart(prod1, 2);

var pw = new ProductWrapper(prod2, 3);
Console.WriteLine(prod2);
Console.WriteLine(prod3);
Console.WriteLine(pw.ToString());

Store.PrintCustomersInformation();

Console.WriteLine();
using GroceryStore.Models;
using GroceryStore.Constants;
using GroceryStore.Models.ProductClasses;

// Customers
Customer cust1 = new Customer("John", "Doe", 22, 'm', true, 0.02f);
Customer cust2 = new Customer("Sam", "Brooks", 67, 'f', true, 0.12f);
Customer cust3 = new Customer("Alois", "Winter", 15, 'm', false);
Customer cust4 = new Customer("Ann", "Siemens", 44, 'f', true, 0.09f);
Customer cust5 = new Customer("Peter", "Parker", 9, 'm', false);

// Products

Product prod1 = new Drink("Coca-Cola", ProductCategories.Drinks, 1.12f, 1);
Product prod2 = new FruitsAndVegetables("Tomatoes", ProductCategories.FruitsAndVegetables, 0.99f);
Product prod3 = new Snacks("Lay's Cheese", ProductCategories.Snacks, 2.49f);
Product prod4 = new Fish("Norway Herring", ProductCategories.Fish, FishType.Ocean, 4.55f);

//cust4.UpdateDiscountCard(false);
//cust1.ChangeCustomerName("John", "Claus");

// Assigning Customers to the store

Store store1 = new Store();
store1.AddCustomer(cust1);
store1.AddCustomer(cust2);
//store1.AddCustomer(cust3);
//store1.AddCustomer(cust4);
//store1.AddCustomer(cust5);

//store1.Customers[0].AddProductToCart(prod1, 2);
//store1.Customers[0].AddProductToCart(prod4, 1);
//store1.Customers[0].AddProductToCart(prod2, 7);

store1.Customers[1].AddProductToCart(prod1, 10);
store1.Customers[1].AddProductToCart(prod4, 3);

//store1.Customers[4].AddProductToCart(prod3, 5);
//store1.Customers[4].AddProductToCart(prod1, 2);

var pw = new ProductWrapper(prod2, 3);
Console.WriteLine(prod2);
Console.WriteLine(prod3);
Console.WriteLine(pw.ToString());

store1.PrintCustomersInformation();

Console.WriteLine();
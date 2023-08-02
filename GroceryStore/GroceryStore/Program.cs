using GroceryStore.Models;
using GroceryStore.Constants;
using System.Runtime.InteropServices;

// Customers 
Customer cust1 = new Customer("John", "Doe", 22, 'm', true, 0.02f);
Customer cust2 = new Customer("Sam", "Brooks", 67, 'f', true, 0.12f);
Customer cust3 = new Customer("Alois", "Winter", 15, 'm', false);
Customer cust4 = new Customer("Ann", "Siemens", 44, 'f', true, 0.09f);
Customer cust5 = new Customer("Peter", "Parker", 9, 'm', false);

// Products

Product prod1 = new Product("Coca-Cola", ProductCategories.Category.Drinks, 1.12f);
Product prod2 = new Product("Tomatoes", ProductCategories.Category.FruitsAndVegetables, 0.99f);
Product prod3 = new Product("Lay's Cheese", ProductCategories.Category.Snacks, 2.49f);
Product prod4 = new Product("Norway Herring", ProductCategories.Category.Fish, 4.55f);

cust4.UpdateDiscountCard(false);
cust1.ChangeCustomerName("John", "Claus");

// Asigning Customers to the store

Store store1 = new Store();
store1.AddCustomer(cust1);
store1.AddCustomer(cust2);
store1.AddCustomer(cust3);
store1.AddCustomer(cust4);
store1.AddCustomer(cust5);

store1.PrintCustomersInformation();



Console.WriteLine(prod4.GetProductInfo());

store1.Customers[0].AddProductToCart(prod1);
store1.Customers[0].AddProductToCart(prod2);
store1.Customers[0].AddProductToCart(prod3);


Console.WriteLine(store1.Customers[0].Cart[0].GetProductInfo());


store1.PrintCustomersInformation();





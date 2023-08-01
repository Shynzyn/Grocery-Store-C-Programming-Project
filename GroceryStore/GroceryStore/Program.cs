using GroceryStore.Models;
using GroceryStore.Constants;


Customer cust1 = new Customer("Max", "Pain", 25, 'm', false);

Product prod1 = new Product("Coca Cola", ProductCategories.Category.Drinks, 1.50);

Store store1 = new Store();

store1.AddCustomer("John", "Doe", 22, 'm', true, 0.02f) ;
store1.AddCustomer("Sam", "Brooks", 67, 'f', true, 0.12f);
store1.AddCustomer("Alois", "Winter", 15, 'm', false);

Console.WriteLine(store1.Customers[0].PersonalDicount);
Console.WriteLine(store1.Customers[1].PersonalDicount);
Console.WriteLine(store1.Customers[2].PersonalDicount);



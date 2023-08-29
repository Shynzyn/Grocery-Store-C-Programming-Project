﻿using GroceryStore.Constants;

namespace GroceryStore.Models.Products;

public abstract class Product
{
    protected Product(string name, double price, int expirationDays = 1)
    {
        Name = name;
        Price = price;
        ExpirationDate = DateTime.Now.AddDays(expirationDays);
    }

    public string Name { get; set; }
    public ProductCategories Category { get; set; }
    public double Price { get; set; }
    public DateTime ExpirationDate { get; }

    public override string ToString()
    {
        return $"({Category}) {Name} ${Price:0.##}, Exp. {ExpirationDate:dd.MM.yy}";
    }
}
using GroceryStore.Constants;

namespace GroceryStore.Models.Products;

public class Snacks : Product
{
    public Snacks(string name, double price, bool isNotFat = false) :
        base(name, price, 90)
    {
        IsNotFat = isNotFat;
        Category = ProductCategories.Snacks;
    }

    public bool IsNotFat { get; set; }

    public override string ToString()
    {
        return $"({Category}) {Name} ${Price:0.00}, Exp. {ExpirationDate:dd.MM.yy}, Fat - {!IsNotFat}";
    }
}
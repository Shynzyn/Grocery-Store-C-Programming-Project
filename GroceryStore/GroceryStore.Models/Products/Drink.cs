using GroceryStore.Constants;

namespace GroceryStore.Models.Products;

public class Drink : Product
{
    public Drink(string name, double price, float volume, bool isAlcohol = false) :
        base(name, price, 30)
    {
        Volume = volume;
        IsAlcohol = isAlcohol;
        Category = ProductCategories.Drinks;
    }

    public bool IsAlcohol { get; set; }
    public float Volume { get; set; }

    public override string ToString()
    {
        var alcohol = IsAlcohol ? "Y" : "N";
        return $"({Category}) {Name} ${Price:0.00}, Exp. {ExpirationDate:dd.MM.yy}, Vol. - {Volume:0.##}, Alcohol - {alcohol}";
    }
}
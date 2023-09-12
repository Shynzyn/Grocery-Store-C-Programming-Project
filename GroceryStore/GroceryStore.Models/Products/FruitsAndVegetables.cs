using GroceryStore.Constants;

namespace GroceryStore.Models.Products;

public class FruitsAndVegetables : Product
{
    public FruitsAndVegetables(string name, double price, float weight = 1) :
        base(name, price, 4)
    {
        Weight = weight;
        Category = ProductCategories.FruitsAndVegetables;
    }

    public float Weight { get; set; }

    public override string ToString()
    {
        return $"({Category.Description()}) {Name} ${Price:0.00}, Exp. {ExpirationDate:dd.MM.yy}, {Weight}kg";
    }
}
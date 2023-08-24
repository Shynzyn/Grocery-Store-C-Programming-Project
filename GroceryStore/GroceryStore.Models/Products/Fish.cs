using GroceryStore.Constants;

namespace GroceryStore.Models.Products;

public class Fish : Product
{
    public Fish(string name, double price, FishType fishType = FishType.Freshwater) :
        base(name, price, 1)
    {
        FishType = fishType;
        Category = ProductCategories.Fish;
    }

    public FishType FishType { get; }

    public override string ToString()
    {
        return $"({Category}) {Name} ${Price:0.00}, Exp. {ExpirationDate:dd.MM.yy}, {FishType}";
    }
}
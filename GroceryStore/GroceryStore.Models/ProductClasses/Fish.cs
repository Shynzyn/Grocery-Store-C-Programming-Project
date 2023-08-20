using GroceryStore.Constants;

namespace GroceryStore.Models.ProductClasses
{
    public class Fish : Product
    {
        public FishType FishType { get; }

        public Fish(string name, double price, FishType fishType = FishType.Freshwater) : base(name,
            price, expirationDays: 1)
        {
            FishType = fishType;
            Category = ProductCategories.Fish;
        }

        public override string ToString()
        {
            return
                $"({Category}) {Name} ${Price:0.00}, Exp. {ExpirationDate:dd.MM.yy}, {FishType}";
        }
    }
}
using GroceryStore.Constants;

namespace GroceryStore.Models.ProductClasses
{
    public class Fish : Product
    {
        public FishType FishType { get; }
        public override int ExpirationDays { get; protected set; } = 1;

        public Fish(string name, string category, FishType fishType, double price) : base(name,
            category, price)
        {
            FishType = fishType;
        }
        public new string ToString()
        {
            return
                $"({Category}) {Name} {Price}, Exp. {ExpirationDate.ToString("dd.MM.yy")}, {FishType}";
        }
    }
}
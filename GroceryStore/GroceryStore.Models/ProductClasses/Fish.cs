using GroceryStore.Constants;

namespace GroceryStore.Models.ProductClasses
{
    public class Fish : Product
    {
        public FishType FishType { get; }
        public override int ExpirationDays { get; protected set; } = 1;

        public Fish(string name, string category, FishType fishType, double price, int amount = 1) : base(name,
            category, price, amount)
        {
            FishType = fishType;
        }
        public new string ToString()
        {
            double result = Price * Amount;
            return
                $"({Category}) {Name} {Price}, Exp. {ExpirationDate.ToString("dd.MM.yy")}, {FishType} - {Amount}x - {result.ToString("0.##")}";
        }
    }
}
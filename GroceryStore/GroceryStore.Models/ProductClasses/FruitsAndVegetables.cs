namespace GroceryStore.Models.ProductClasses
{
    public class FruitsAndVegetables : Product
    {
        public override int ExpirationDays { get; protected set; } = 4;

        public FruitsAndVegetables(string name, string category, double price, int amount = 1) : base(name, category, price, amount)
        {
        }
    }
}
namespace GroceryStore.Models.ProductClasses
{
    public class FruitsAndVegetables : Product
    {
        public override int ExpirationDays { get; protected set; } = 4;

        public FruitsAndVegetables(string name, string category, double price) : base(name, category, price)
        {
        }
    }
}
namespace GroceryStore.Models.ProductClasses
{
    public class Snacks : Product
    {
        public override int ExpirationDays { get; protected set; } = 90;

        public Snacks(string name, string category, double price, int amount = 1) : base(name, category, price, amount)
        {
        }
    }
}

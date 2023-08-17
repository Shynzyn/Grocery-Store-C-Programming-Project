namespace GroceryStore.Models.ProductClasses
{
    public class Snacks : Product
    {
        public override int ExpirationDays { get; protected set; } = 90;

        public Snacks(string name, string category, double price) : base(name, category, price)
        {
        }
    }
}

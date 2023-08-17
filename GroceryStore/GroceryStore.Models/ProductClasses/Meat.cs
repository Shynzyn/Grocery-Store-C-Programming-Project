namespace GroceryStore.Models.ProductClasses
{
    public class Meat : Product
    {
        public override int ExpirationDays { get; protected set; }

        public Meat(string name, string category, double price, int amount = 1) : base(name, category, price, amount)
        {
        }
    }
}

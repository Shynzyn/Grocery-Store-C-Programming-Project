namespace GroceryStore.Models.ProductClasses
{
    public class Meat : Product
    {
        public override int ExpirationDays { get; protected set; }

        public Meat(string name, string category, double price) : base(name, category, price)
        {
        }
    }
}

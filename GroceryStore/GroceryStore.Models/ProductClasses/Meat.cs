using GroceryStore.Constants;

namespace GroceryStore.Models.ProductClasses
{
    public class Meat : Product
    {
        public Meat(string name, double price) : base(name, price, expirationDays: 2)
        {
            Category = ProductCategories.Meat;
        }

        public override string ToString()
        {
            return
                $"({Category}) {Name} ${Price:0.00}, Exp. {ExpirationDate:dd.MM.yy}";
        }
    }
}
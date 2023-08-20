using GroceryStore.Constants;

namespace GroceryStore.Models.ProductClasses
{
    public class Snacks : Product
    {
        public bool IsNotFat { get; set; }

        public Snacks(string name, double price, bool isNotFat = false) : base(name, price,
            expirationDays: 90)
        {
            IsNotFat = isNotFat;
            Category = ProductCategories.Snacks;
        }

        public override string ToString()
        {
            return
                $"({Category}) {Name} ${Price:0.00}, Exp. {ExpirationDate:dd.MM.yy}, Fat - {!IsNotFat}";
        }
    }
}
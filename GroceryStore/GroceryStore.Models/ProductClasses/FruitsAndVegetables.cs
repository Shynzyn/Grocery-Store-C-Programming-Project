using GroceryStore.Constants;

namespace GroceryStore.Models.ProductClasses
{
    public class FruitsAndVegetables : Product
    {
        public float Weight { get; set; }

        public FruitsAndVegetables(string name, double price, float weight = 1) : base(name,
            price, expirationDays: 4)
        {
            Weight = weight;
            Category = ProductCategories.FruitsAndVegetables;
        }

        public override string ToString()
        {
            return
                $"({Category}) {Name} ${Price:0.00}, Exp. {ExpirationDate:dd.MM.yy}, {Weight}kg";
        }
    }
}
using GroceryStore.Constants;

namespace GroceryStore.Models.ProductClasses
{
    public class Drink : Product
    {
        public bool IsAlcohol { get; set; }
        public float Volume { get; set; }

        public Drink(string name, double price, float volume, bool isAlcohol = false) :
            base(name, price, expirationDays: 30)
        {
            Volume = volume;
            IsAlcohol = isAlcohol;
            Category = ProductCategories.Fish;
        }


        public override string ToString()
        {
            string alcohol = (IsAlcohol) ? "Y" : "N";
            return
                $"({Category}) {Name} ${Price:0.00}, Exp. {ExpirationDate:dd.MM.yy}, Vol. - {Volume:0.##}, Alcohol - {alcohol}";
        }
    }
}
namespace GroceryStore.Models.ProductClasses
{
    public class Drink : Product
    {
        internal bool IsAlcohol { get; set; }
        internal float Volume { get; set; }
        public override int ExpirationDays { get; protected set; } = 30;

        public Drink(string name, string category, double price, float volume,
            bool isAlcohol = false, int amount = 1) :
            base(name, category, price, amount)
        {
            this.Volume = volume;
            IsAlcohol = isAlcohol;
        }

        public new string ToString()
        {
            double result = Price * Amount;
            string alcohol = (IsAlcohol) ? "Y" : "N";
            return
                $"({Category}) {Name} {Price}, Exp. {ExpirationDate.ToString("dd.MM.yy")}, Vol. - {Volume.ToString("0.##")}, Alcohol - {alcohol} - {Amount}x - {result.ToString("0.##")}";
        }
    }
}
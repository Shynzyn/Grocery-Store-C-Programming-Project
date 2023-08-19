using GroceryStore.Constants;

namespace GroceryStore.Models.ProductClasses
{
    /*Make some changes in Fish class:
Expiration days = 1
Add FishType field and add it as a parameter to the constructor. FishType can take values only from the following list: Sea, Freshwater, Ocean
Add local ToString() method, which:
Will return string in format ({Category}) {Name} {Price}, Exp. {ExpirationDate}, {FishType}
ToString() method must be created using hiding
*/
    public class Fish : Product
    {
        public FishType FishType { get; }
        public override int ExpirationDays { get; protected set; } = 1;

        public Fish(string name, string category, FishType fishType, double price) : base(name,
            category, price)
        {
            FishType = fishType;
        }

        public new string ToString()
        {
            return
                $"({Category}) {Name} {Price}, Exp. {ExpirationDate:dd.MM.yy}, {FishType}";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using util = Utility.Utility;

namespace GroceryStore.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        private char sex;
        public char Sex
        {
            get { return sex; }
            set { sex = char.ToUpper(value); }
        }
        public bool hasDiscountCard { get; set; }

        private float personalDiscount;

        public float PersonalDiscount
        {
            get
            {
                return (hasDiscountCard) ? personalDiscount : 0f;
            }
            set
            {   
                personalDiscount = value;
            }
        }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public Product[] Cart = new Product[0];

        private int cartCount = 0;

        public Customer(string FirstName, string LastName, int Age, char Sex, bool hasDiscountCard, float personalDiscount=0.05f)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Sex = Sex;
            this.hasDiscountCard = hasDiscountCard;
            this.PersonalDiscount = personalDiscount;
        }

        public void ChangeCustomerName(string customerName, string customerLastName)
        {
            this.FirstName = customerName;
            this.LastName = customerLastName;
            Console.WriteLine($"Customer name changed to: {FullName}");
        }

        public void UpdateDiscountCard(bool hasDiscountCard, float personalDiscount=0.05f)
        {
            this.hasDiscountCard = hasDiscountCard;
            this.PersonalDiscount = personalDiscount;
            if ( this.hasDiscountCard)
            {
                Console.WriteLine($"Updated: Customer [{FullName}] has card - Discount ammount: {this.PersonalDiscount}");
            }
            else
            {
                Console.WriteLine($"Updated: Customer [{FullName}] doesn't have card - No discount is available");
            }
        }

        public string GetCustomerInfo()
        {   
        
            string card = (hasDiscountCard) ? "YES" : "NO";
            string header = "--------------------------------------------------------------------------------------------------------------------------------------------------\n";

            if (Cart.Length == 0)
            {
                string emptyCart = "EMPTY";
                string info = $"| {util.CenterAlign(FullName, 30)} | {util.CenterAlign(Age.ToString(), 3)} | {util.CenterAlign(Sex.ToString(), 5)} | {util.CenterAlign(card, 17)} | {util.CenterAlign((PersonalDiscount * 100).ToString() + "%", 17)} | {util.CenterAlign(emptyCart, 55)} |";
                return header + info;
            }
            else if (Cart.Length == 1)
            {
                string cartString = Cart[0].GetProductInfo();
                string info = $"| {util.CenterAlign(FullName, 30)} | {util.CenterAlign(Age.ToString(), 3)} | {util.CenterAlign(Sex.ToString(), 5)} | {util.CenterAlign(card, 17)} | {util.CenterAlign((PersonalDiscount * 100).ToString() + "%", 17)} | {cartString.PadRight(55)} |";
                return header + info;
            }
            else
            {   
                string emptyLine = $"|{util.CenterAlign("", 32)}|{util.CenterAlign("", 5)}|{util.CenterAlign("", 7)}|{util.CenterAlign("", 19)}|{util.CenterAlign("", 19)}";
                string cartStrings = "";
                double sum = 0;

                foreach (var cartElement in Cart)
                {
                    double elementTotalPrice = cartElement.Price * cartElement.Amount;
                    sum += elementTotalPrice;
                    string cartElementString = $"|{cartElement.GetProductInfo().PadRight(57)}|\n";
                    cartStrings += cartElementString + emptyLine;
                }
                string info = $"| {util.CenterAlign(FullName, 30)} | {util.CenterAlign(Age.ToString(), 3)} | {util.CenterAlign(Sex.ToString(), 5)} | {util.CenterAlign(card, 17)} | {util.CenterAlign((PersonalDiscount * 100).ToString() + "%", 17)} {util.CenterAlign(cartStrings, 50)} |";
                string total = $"TOTAL = ${sum.ToString("0.00")} - DISCOUNT - {PersonalDiscount * 100}% - ${(sum - (sum * PersonalDiscount)).ToString("0.00")}";
                string totalFormater = total.PadRight(56)+"|";
                return header + info + totalFormater;
            }
        }
        public void AddProductToCart(Product product, int Amount=1)
        {
            if (Cart.Length <= cartCount)
            {
                Array.Resize(ref Cart, cartCount + 1);
            }
            Cart[cartCount] = product;
            cartCount++;
            Console.WriteLine($"Product: {product.GetProductInfo()} x {Amount} was added to {FullName}'s cart.");
        }

    }
}

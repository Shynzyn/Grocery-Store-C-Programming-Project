using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using util = GroceryStore.Utils.Utility;

namespace GroceryStore.Models
{
    public class Customer
    {
        private char _sex;
        private float _personalDiscount;
        private int _cartCount = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public char Sex
        {
            get => _sex;
            set => _sex = char.ToUpper(value);
        }

        public bool hasDiscountCard { get; set; }

        public float PersonalDiscount
        {
            get => (hasDiscountCard) ? _personalDiscount : 0f;
            set => _personalDiscount = value;
        }

        public string FullName => $"{FirstName} {LastName}";

        public ProductWrapper[] Cart = new ProductWrapper[0];

        public Customer(string firstName, string lastName, int age, char sex, bool hasDiscountCard,
            float personalDiscount = 0.05f)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Sex = sex;
            this.hasDiscountCard = hasDiscountCard;
            this.PersonalDiscount = personalDiscount;
        }

        public void ChangeCustomerName(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            Console.WriteLine($"Customer name changed to: {FullName}");
        }

        public void UpdateDiscountCard(bool hasDiscountCard, float personalDiscount = 0.05f)
        {
            this.hasDiscountCard = hasDiscountCard;
            this.PersonalDiscount = personalDiscount;
            if (this.hasDiscountCard)
            {
                Console.WriteLine(
                    $"Updated: Customer [{FullName}] has card - Discount amount: {this.PersonalDiscount}");
            }
            else
            {
                Console.WriteLine($"Updated: Customer [{FullName}] doesn't have card - No discount is available");
            }
        }

        public override string ToString()
        {
            string card = (hasDiscountCard) ? "YES" : "NO";
            string header = new string('-', 170) + "\n";

            if (Cart.Length <= 0)
            {
                string emptyCart = "EMPTY";
                string info =
                    $"| {util.CenterAlign(FullName, 30)} | {util.CenterAlign(Age.ToString(), 3)} | {util.CenterAlign(Sex.ToString(), 5)} |" +
                    $" {util.CenterAlign(card, 17)} | {util.CenterAlign((PersonalDiscount * 100) + "%", 17)} | {util.CenterAlign(emptyCart, 79)} |";
                return header + info;
            }
            else
            {
                string emptyLine =
                    $"|{util.CenterAlign("", 32)}|{util.CenterAlign("", 5)}|{util.CenterAlign("", 7)}|{util.CenterAlign("", 19)}|{util.CenterAlign("", 19)}";
                string cartStrings = "";
                double sum = 0;

                foreach (var cartElement in Cart)
                {
                    double elementTotalPrice = cartElement.Product.Price * cartElement.Amount;
                    sum += elementTotalPrice;
                    string cartElementString = $"|{cartElement,-81}|\n";
                    cartStrings += cartElementString + emptyLine;
                }

                string info =
                    $"| {util.CenterAlign(FullName, 30)} | {util.CenterAlign(Age.ToString(), 3)} | {util.CenterAlign(Sex.ToString(), 5)} |" +
                    $" {util.CenterAlign(card, 17)} | {util.CenterAlign((PersonalDiscount * 100) + "%", 17)} {util.CenterAlign(cartStrings, 50)} |";
                string total =
                    $"TOTAL = ${sum:0.00} - DISCOUNT - {PersonalDiscount * 100}% - ${(sum - (sum * PersonalDiscount)):0.00}";
                string totalFormater = total.PadRight(80) + "|";
                return header + info + totalFormater;
            }
        }

        public void AddProductToCart(Product product, int amount)
        {
            if (Cart.Length <= _cartCount)
            {
                Array.Resize(ref Cart, _cartCount + 1);
            }

            Cart[_cartCount] = new ProductWrapper(product, amount);
            _cartCount++;
            Console.WriteLine($"Product: {product} was added to {FullName}'s cart.");
        }
    }
}
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
        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }
        public Product[] Cart = new Product[0];

        public Customer(string firstName, string lastName, int age, char sex, bool hasDiscountCard, float personalDiscount = 0.05f)
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
                string info = $"| {util.CenterAlign(FullName, 30)} | {util.CenterAlign(Age.ToString(), 3)} | {util.CenterAlign(Sex.ToString(), 5)} |" +
                    $" {util.CenterAlign(card, 17)} | {util.CenterAlign((PersonalDiscount * 100).ToString() + "%", 17)} | {util.CenterAlign(emptyCart, 55)} |";
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
                string info = $"| {util.CenterAlign(FullName, 30)} | {util.CenterAlign(Age.ToString(), 3)} | {util.CenterAlign(Sex.ToString(), 5)} |" +
                    $" {util.CenterAlign(card, 17)} | {util.CenterAlign((PersonalDiscount * 100).ToString() + "%", 17)} {util.CenterAlign(cartStrings, 50)} |";
                string total = $"TOTAL = ${sum.ToString("0.00")} - DISCOUNT - {PersonalDiscount * 100}% - ${(sum - (sum * PersonalDiscount)).ToString("0.00")}";
                string totalFormater = total.PadRight(56) + "|";
                return header + info + totalFormater;
            }
        }

        public void AddProductToCart(Product product, int amount = 1)
        {
            if (Cart.Length <= _cartCount)
            {
                Array.Resize(ref Cart, _cartCount + 1);
            }

            Product newProduct = new Product(product.Name, product.Category, product.Price, amount);
            Cart[_cartCount] = newProduct;
            _cartCount++;
            Console.WriteLine($"Product: {newProduct.GetProductInfo()} was added to {FullName}'s cart.");
        }

    }
}

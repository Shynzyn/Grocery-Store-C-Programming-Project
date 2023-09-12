using System.Linq.Expressions;
using GroceryStore.Core.Exceptions;
using GroceryStore.Core.Helpers;
using GroceryStore.Models.Products;
using Newtonsoft.Json;
using util = GroceryStore.Utils.Utility;

namespace GroceryStore.Models;

public class Customer
{
    private float _personalDiscount;
    private char _sex;

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
        get => hasDiscountCard ? _personalDiscount : 0f;
        set => _personalDiscount = value;
    }

    public string FullName => $"{FirstName} {LastName}";

    private static JsonSerializerSettings customSettings = new JsonSerializerSettings
    {
        Formatting = Formatting.Indented,
        Converters = { new ProductConverter() }
    };

    public List<ProductWrapper> Cart = JsonHelper.LoadFromJson<ProductWrapper>("customers.json", customSettings).ToList();

    public Customer(string firstName, string lastName, int age, char sex, bool hasDiscountCard,
        float personalDiscount = 0.05f)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Sex = sex;
        this.hasDiscountCard = hasDiscountCard;
        PersonalDiscount = personalDiscount;
    }

    public void ChangeCustomerName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Console.WriteLine($"Customer name changed to: {FullName}");
    }

    public void UpdateDiscountCard(bool hasDiscountCard, float personalDiscount = 0.05f)
    {
        this.hasDiscountCard = hasDiscountCard;
        PersonalDiscount = personalDiscount;
        if (this.hasDiscountCard)
        {
            Console.WriteLine($"Updated: Customer [{FullName}] has card - Discount amount: {PersonalDiscount}");
        }
        else
        {
            Console.WriteLine($"Updated: Customer [{FullName}] doesn't have card - No discount is available");
        }
    }

    public override string ToString()
    {
        var card = hasDiscountCard ? "YES" : "NO";
        var header = new string('-', 180) + "\n";

        if (Cart.Count <= 0)
        {
            var emptyCart = "EMPTY";
            var info = $"| {util.CenterAlign(FullName, 30)} | {util.CenterAlign(Age.ToString(), 3)} | {util.CenterAlign(Sex.ToString(), 5)} |" +
                       $" {util.CenterAlign(card, 17)} | {util.CenterAlign(PersonalDiscount * 100 + "%", 17)} | {util.CenterAlign(emptyCart, 89)} |";
            return header + info;
        }
        else
        {
            var emptyLine = $"|{util.CenterAlign("", 32)}|{util.CenterAlign("", 5)}|{util.CenterAlign("", 7)}|{util.CenterAlign("", 19)}|{util.CenterAlign("", 19)}";
            var sum = Cart.Sum(item => item.Amount * item.Product.Price);

            var cartString = string.Join("", Cart.Select(cartElement =>
                $"| {cartElement.Product} - {cartElement.Amount:0.##}x - {cartElement.Amount * cartElement.Product.Price:0.##}$".PadRight(92) +
                $"|\n{emptyLine}"));

            var info = $"| {util.CenterAlign(FullName, 30)} | {util.CenterAlign(Age.ToString(), 3)} | {util.CenterAlign(Sex.ToString(), 5)} |" +
                       $" {util.CenterAlign(card, 17)} | {util.CenterAlign(PersonalDiscount * 100 + "%", 17)} {util.CenterAlign(cartString, 90)}|";
            var total = $" TOTAL = ${sum:0.00} - DISCOUNT - {PersonalDiscount * 100}% - ${sum - sum * PersonalDiscount:0.00}".PadRight(91) + "|";
            return header + info + total;
        }
    }

    public void AddProductToCart<T>(T product, int amount = 1) where T : Product
    {
        try
        {
            if (product is Drink drink && drink.IsAlcohol && Age < 18)
            {
                throw new UnderAgeException();
            }

            if (product.ExpirationDate < DateTime.Today)
            {
                throw new ExpiredProductException();
            }

            Cart.Add(new ProductWrapper(product, amount));
            Console.WriteLine($"Product: {product} was added to {FullName}'s cart.");
        }
        catch (UnderAgeException ex)
        {
            Console.WriteLine($"Customer {FullName} is unable to buy the following products: {product.Name} according to age restrictions");
        }
        catch (ExpiredProductException ex)
        {
            Console.WriteLine($"Customer {FullName} is unable to buy the following products: {product.Name} according to expiry date {product.ExpirationDate}");
        }
    }
}
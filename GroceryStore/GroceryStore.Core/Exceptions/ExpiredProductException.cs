using GroceryStore.Models;

namespace GroceryStore.Core.Exceptions
{
    public class ExpiredProductException : ApplicationException
    {
        public override string Message { get; }

        public ExpiredProductException(Customer customer)
        {
            var expiredProducts = customer.Cart.Where(item => item.Product.ExpirationDate <= DateTime.Today).Select(item => item.Product.Name);

            Message = $"Customer {customer.FullName} is unable to buy the following products {string.Join(", ", expiredProducts)} according to expiry date {date}";
        }
    }
}
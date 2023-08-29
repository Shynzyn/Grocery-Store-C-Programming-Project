using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Models;
using GroceryStore.Models.Products;

namespace GroceryStore.Core.Exceptions
{
    public class UnderAgeException : ApplicationException
    {
        public override string Message { get; }

        public UnderAgeException(Customer customer)
        {
            var unavailableProducts = customer.Cart.Where(item => item.Product is Drink drink && drink.IsAlcohol)
                .Select(item => item.Product.Name);

            Message = $"Customer {customer.FullName} is unable to buy following products {string.Join(", ", unavailableProducts)} according to age restrictions";
        }
    }
}
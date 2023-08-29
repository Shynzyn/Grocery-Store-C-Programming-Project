using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.Helpers
{
    public static class CollectionHelper
    {
        public static void AddCustomer<T>(this ICollection<T> collection, T customer)
        {
            collection.Add(customer);
            JsonHelper.SaveToJson(customer, "customers.json");
        }
    }
}
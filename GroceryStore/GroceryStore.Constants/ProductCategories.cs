using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Constants
{
    public class ProductCategories
    {
        public enum Category
        {
            FruitsAndVegetables,
            Meat,
            Fish,
            Snacks,
            Drinks
        }

        public static string GetCategoryName(Category category)
        {
            switch (category)
            {
                case Category.FruitsAndVegetables:
                    return "Fruits & Vegetables";
                case Category.Meat:
                    return "Meat";
                case Category.Fish:
                    return "Fish";
                case Category.Snacks:
                    return "Snacks";
                case Category.Drinks:
                    return "Drinks";
                default:
                    return "Unknown Category";
            }
        }
    }
}

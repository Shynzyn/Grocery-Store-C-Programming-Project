namespace GroceryStore.Constants;

public enum ProductCategories
{
    FruitsAndVegetables,
    Meat,
    Fish,
    Snacks,
    Drinks,
}

public static class ProductCategoriesExtensions
{
    public static string Description(this ProductCategories category)
    {
        switch (category)
        {
            case ProductCategories.FruitsAndVegetables:
                return "Fruits & Vegetables";
            default:
                return category.ToString();
        }
    }
}
namespace GroceryStore.Models.Products;

public class ProductWrapper
{
    public ProductWrapper(Product product, int amount)
    {
        Product = product;
        Amount = amount;
    }

    public Product Product { get; set; }
    public int Amount { get; set; }

    public override string ToString()
    {
        return Product.ToString();
    }
}
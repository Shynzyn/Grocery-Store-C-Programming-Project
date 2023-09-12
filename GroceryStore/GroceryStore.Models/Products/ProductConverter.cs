using GroceryStore.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GroceryStore.Models.Products;

public class ProductConverter : JsonConverter<Product>
{
    public override Product ReadJson(JsonReader reader, Type objectType, Product existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JObject jsonObject = JObject.Load(reader);
        int category = jsonObject.Value<int>("Category");

        switch ((ProductCategories)category)
        {
            case ProductCategories.Drinks:
                return jsonObject.ToObject<Drink>();
            case ProductCategories.Fish:
                return jsonObject.ToObject<Fish>();
            case ProductCategories.FruitsAndVegetables:
                return jsonObject.ToObject<FruitsAndVegetables>();
            case ProductCategories.Snacks:
                return jsonObject.ToObject<Snacks>();
            case ProductCategories.Meat:
                return jsonObject.ToObject<Meat>();
            default:
                throw new InvalidOperationException("Unknown product category");
        }
    }

    public override void WriteJson(JsonWriter writer, Product value, JsonSerializer serializer)
    {
        // For serialization, you can use the default behavior.
        serializer.Serialize(writer, value);
    }
}
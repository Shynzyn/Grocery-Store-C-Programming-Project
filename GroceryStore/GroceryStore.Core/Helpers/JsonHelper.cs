using Newtonsoft.Json;

namespace GroceryStore.Core.Helpers
{
    public class JsonHelper
    {
        public static void SaveToJson<T>(ICollection<T> collection, string fileName)
        {
            string filePath = Path.Combine(@"C:\Users\Marcin.Petrulevic\Desktop\Internship\Grocery-Store-C-Programming-Project\GroceryStore\GroceryStore\Resources", fileName);
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            // Serialize the collection of objects to JSON.
            string jsonString = JsonConvert.SerializeObject(collection, settings);

            // Write the JSON data to the file.
            File.WriteAllText(filePath, jsonString);
        }

        public static ICollection<T> LoadFromJson<T>(string fileName, JsonSerializerSettings settings = null)
        {
            string filePath = Path.Combine(@"C:\Users\Marcin.Petrulevic\Desktop\Internship\Grocery-Store-C-Programming-Project\GroceryStore\GroceryStore\Resources", fileName);

            if (!File.Exists(filePath))
            {
                // If the file does not exist, return an empty collection.
                return new List<T>();
            }

            string jsonString = File.ReadAllText(filePath);

            if (settings == null)
            {
                // Use default settings if no custom settings are provided
                return JsonConvert.DeserializeObject<ICollection<T>>(jsonString);
            }
            else
            {
                // Use custom settings if provided
                return JsonConvert.DeserializeObject<ICollection<T>>(jsonString, settings);
            }
        }
    }
}
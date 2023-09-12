using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft;

namespace GroceryStore.Core.Helpers
{
    public class JsonHelper
    {
        public static void SaveToJson<T>(T obj, string fileName)
        {
            string filePath = @"C:\Users\Marcin.Petrulevic\Desktop\Internship\Grocery-Store-C-Programming-Project\GroceryStore\GroceryStore\Resources\" + fileName;
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string jsonString = JsonConvert.SerializeObject(obj, settings);
            File.WriteAllText(filePath, jsonString);
        }

        public static T LoadFromJson<T>(string fileName, JsonSerializerSettings settings = null)
        {
            string filePath = @"C:\Users\Marcin.Petrulevic\Desktop\Internship\Grocery-Store-C-Programming-Project\GroceryStore\GroceryStore\Resources\" + fileName;
            string jsonString = File.ReadAllText(filePath);

            if (settings == null)
            {
                // Use default settings if no custom settings are provided
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            else
            {
                // Use custom settings if provided
                return JsonConvert.DeserializeObject<T>(jsonString, settings);
            }
        }
    }
}
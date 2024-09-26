using System.Text.Json;

namespace PostManCloneLibrary
{
    public class JsonFormatter
    {

        public static string FormatJson(string json)
        {
            string prettyJson;
            try
            {
                if (json == "")
                    return "";
                var jsonElement = JsonSerializer.Deserialize<JsonElement>(json);
                prettyJson = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions { WriteIndented = true });
            }
            catch
            {
                throw;
            }
            return prettyJson;
        }
    }
}
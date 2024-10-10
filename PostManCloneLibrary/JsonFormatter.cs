using System.Text.Json;

namespace PostManCloneLibrary
{
    public class JsonFormatter
    {
        public static readonly JsonSerializerOptions options = new() { WriteIndented = true };
        public static string FormatJson(string json)
        {
            string prettyJson;

            try
            {
                if (json == "")
                    return "";
                JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(json);
                prettyJson = JsonSerializer.Serialize(jsonElement, options);
            }
            catch
            {
                throw;
            }
            return prettyJson;
        }
    }
}
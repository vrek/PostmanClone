using System.Text.Json;

namespace PostManCloneLibrary
{
    public class JsonParser
    {
        public static Dictionary<string, object> ParseJSONObject(string input)
        {
            try
            {
                // Deserialize single JSON object into a dictionary
                Dictionary<string, object>? parsed = JsonSerializer.Deserialize<Dictionary<string, object>>(input);
                return parsed ?? [];
            }
            catch (JsonException)
            {
                throw new FormatException("Input is not a valid JSON object.");
            }
        }

        public static List<Dictionary<string, object>> ParseJsonString(string input)
        {
            try
            {
                // First try to deserialize into a list of JSON objects
                List<Dictionary<string, object>>? parsedList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(input);
                return parsedList ?? [];
            }
            catch (JsonException)
            {
                // If it fails, try to parse as a single JSON object
                Dictionary<string, object> singleParsedObject = ParseJSONObject(input);
                return [singleParsedObject];
            }
        }
    }
}

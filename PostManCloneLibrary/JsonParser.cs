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
                var parsed = JsonSerializer.Deserialize<Dictionary<string, object>>(input);
                return parsed ?? new Dictionary<string, object>();
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
                var parsedList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(input);
                return parsedList ?? new List<Dictionary<string, object>>();
            }
            catch (JsonException)
            {
                // If it fails, try to parse as a single JSON object
                var singleParsedObject = ParseJSONObject(input);
                return new List<Dictionary<string, object>> { singleParsedObject };
            }
        }
    }
}

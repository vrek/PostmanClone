using System.Text.Json;

namespace PostManCloneLibrary
{
    public class JSONValidator
    {
        public static bool ValidateJSON(string input)
        {
            if (input.StartsWith("Error:"))
            {
                throw new HttpRequestException("The server you are trying to connect to returned an error");
            }
            if (string.IsNullOrEmpty(input))
            {
                throw new FormatException("The input can not be empty or whitespace");
            }
            try
            {
                _ = JsonDocument.Parse(input);
            }
            catch
            {
                throw new FormatException("Invalid JSON format");
            }
            return true;
        }
    }
}

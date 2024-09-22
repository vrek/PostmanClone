namespace PostManCloneLibrary
{
    public class JSONValidator
    {
        public bool ValidateJSON(string input)
        {
            if (!input.StartsWith("{") || !input.EndsWith("}"))
            {
                throw new FormatException("JSON should start and end with curly braces");
                //return false;
            }
            var JSONObjects = input.Split(',');
            foreach (var JSONObject in JSONObjects)
            {
                string name = JSONObject.Split(':')[0].Trim();
                if (!name.StartsWith("\"") && !name.EndsWith("\""))
                {
                    throw new FormatException($"{name} missing a quote");
                }
            }
            return true;
        }
    }
}

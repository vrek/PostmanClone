namespace PostManCloneLibrary
{
    public class JsonParser
    {
        public static Dictionary<string, string> ParseJSONObject(string input)
        {
            Dictionary<string, string> Result = new();
            var JSONObject = input.Split(',');

            foreach (var item in JSONObject)
            {
                Result.Add(item.Split(':')[0], item.Split(':')[1]);
            }
            return Result;
        }
        public static List<Dictionary<string, string>> ParseJsonString(string input)
        {
            List<Dictionary<string, string>> Result = new();
            if (input[0] == '{')
            {
                // Remove the outer braces and split by commas
                var innerContent = input[1..^1];

                // Split the inner content by commas for separate JSON objects
                var jsonObjects = innerContent.Split(new[] { "},{" }, StringSplitOptions.None);

                foreach (var jsonObject in jsonObjects)
                {
                    Result.Add(ParseJSONObject(jsonObject.Trim('{', '}')));
                }
            }
            else { Result.Add(ParseJSONObject(input)); }
            return Result;
        }
    }
}

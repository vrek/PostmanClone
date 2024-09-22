namespace PostManCloneLibrary
{
    class JsonParser
    {
        public static Dictionary<string, string> ParseJSON(string input)
        {
            Dictionary<string, string> Result = new();
            var JSONObject = input.Split(',');

            foreach (var item in JSONObject)
            {
                Result.Add(item.Split(':')[0], item.Split(':')[1]);
            }
            return Result;
        }
    }
}

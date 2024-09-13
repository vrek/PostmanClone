using System.Text.Json;

namespace PostManCloneLibrary
{
    public class APIAccess : IAPIAccess
    {
        public readonly HttpClient client = new();
        public async Task<string> CallAPI(string url, bool formatOutput = true, HttpAction action = HttpAction.GET)
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                if (formatOutput)
                {
                    json = FormatJson(json);
                }
                return json;
            }
            else
            {
                return $"Error: {response.StatusCode}";
            }
        }

        private static string FormatJson(string json)
        {
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(json);
            string prettyJon = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions { WriteIndented = true });
            json = prettyJon;
            return json;
        }

        public bool IsValidUrl(string url)
        {

            if (string.IsNullOrEmpty(url))
            {
                return false;
            }
            bool output = Uri.TryCreate(url, UriKind.Absolute, out Uri uriOutput) && (uriOutput.Scheme == Uri.UriSchemeHttps);
            return output;
        }
    }
}

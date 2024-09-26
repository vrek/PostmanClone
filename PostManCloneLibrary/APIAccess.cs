using System.Text;

namespace PostManCloneLibrary
{
    public class APIAccess : IAPIAccess
    {
        private readonly HttpClient _client;

        public APIAccess(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> CallAPI(string url, string content, HttpAction action = HttpAction.GET)
        {
            StringContent stringContent = new(content, Encoding.UTF8, "application/json");
            return await CallAPI(url, stringContent, action);
        }


        public async Task<string> CallAPI(string url, HttpContent? content = null, HttpAction action = HttpAction.GET)
        {
            HttpResponseMessage? response;

            switch (action)
            {
                case HttpAction.GET:
                    response = await _client.GetAsync(url);
                    break;
                case HttpAction.POST:
                    response = await _client.PostAsync(url, content);
                    break;
                case HttpAction.PATCH:
                    response = await _client.PatchAsync(url, content);
                    break;
                case HttpAction.PUT:
                    response = await _client.PutAsync(url, content);
                    break;
                case HttpAction.DELETE:
                    response = await _client.DeleteAsync(url);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return json;
            }
            else
            {
                return $"Error: {response.StatusCode}";
            }
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

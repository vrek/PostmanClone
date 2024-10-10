using log4net;
using log4net.Config;
using System.Text;


namespace PostManCloneLibrary
{
    public class APIAccess : IAPIAccess
    {
        private readonly HttpClient _client;

        //private ILogDB _logDB;

        public APIAccess(HttpClient client)
        {
            _client = client;


            log4net.Repository.ILoggerRepository logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            _ = XmlConfigurator.Configure(logRepository, new FileInfo("App.config"));
            //var LogDB = new LogDB();
        }

        public async Task<string> CallAPI(string url, ILog _log, string JSONcontent, HttpAction action = HttpAction.GET)
        {
            StringContent stringContent = new(JSONcontent, Encoding.UTF8, "application/json");
            return await CallAPI(url, _log, stringContent, action);

        }

        public async Task<string> CallAPI(string url, ILog _log, HttpContent? content = null, HttpAction action = HttpAction.GET)
        {
            HttpResponseMessage? response = action switch
            {
                HttpAction.GET => await _client.GetAsync(url),
                HttpAction.POST => await _client.PostAsync(url, content),
                HttpAction.PATCH => await _client.PatchAsync(url, content),
                HttpAction.PUT => await _client.PutAsync(url, content),
                HttpAction.DELETE => await _client.DeleteAsync(url),
                _ => throw new ArgumentOutOfRangeException(nameof(action), action, null),
            };
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return json;
            }
            else
            {
                _log.Error($"Status Code was {response.StatusCode}");
                return $"Error: {response.StatusCode}";
            }
        }


        public bool IsValidUrl(string url)
        {

            if (string.IsNullOrEmpty(url))
            {
                return false;
            }
            bool output = Uri.TryCreate(url, UriKind.Absolute, out Uri? uriOutput) && (uriOutput.Scheme == Uri.UriSchemeHttps);
            return output;
        }
    }
}

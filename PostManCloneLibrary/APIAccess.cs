using log4net;
using log4net.Config;
using System.Text;


namespace PostManCloneLibrary
{
    public class APIAccess : IAPIAccess
    {
        private readonly HttpClient _client;
        private readonly ILog _log;

        public APIAccess(HttpClient client, ILog log)
        {
            _client = client;
            _log = log;
            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("App.config"));
            var LogDB = new LogDB();
            LogDB.InitializeDB();
        }

        public async Task<string> CallAPI(string url, ILog _log, string JSONcontent, HttpAction action = HttpAction.GET)
        {
            StringContent stringContent = new(JSONcontent, Encoding.UTF8, "application/json");
            return await CallAPI(url, _log, stringContent, action);

        }

        public async Task<string> CallAPI(string url, ILog _log, HttpContent? content = null, HttpAction action = HttpAction.GET)
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
                //_log.Info(json);
                return json;
            }
            else
            {
                _log.Error($"Status Code was {response.StatusCode}");
                return $"Error: {response.StatusCode.ToString()}";
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

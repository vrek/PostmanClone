

using log4net;

namespace PostManCloneLibrary
{
    public interface IAPIAccess
    {
        Task<string> CallAPI(string url, ILog _log, string content, HttpAction action = HttpAction.GET);
        Task<string> CallAPI(string url, ILog _log, HttpContent? content = null, HttpAction action = HttpAction.GET);
        bool IsValidUrl(string url);
    }
}
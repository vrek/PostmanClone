

namespace PostManCloneLibrary
{
    public interface IAPIAccess
    {
        Task<string> CallAPI(string url, string content, HttpAction action = HttpAction.GET);
        Task<string> CallAPI(string url, HttpContent? content = null, HttpAction action = HttpAction.GET);
        bool IsValidUrl(string url);
    }
}
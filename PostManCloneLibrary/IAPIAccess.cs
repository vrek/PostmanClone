
namespace PostManCloneLibrary
{
    public interface IAPIAccess
    {
        Task<string> CallAPI(string url, bool formatOutput = true, HttpAction action = HttpAction.GET);
        bool IsValidUrl(string url);
    }
}
namespace PostManCloneLibrary
{
    public interface ILogDB
    {
        //string GetConnectionString();
        public void InsertResults(List<Dictionary<string, object>> responses);
        public void Dispose();
    }
}
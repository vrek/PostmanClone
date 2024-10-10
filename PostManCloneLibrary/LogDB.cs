using PostManCloneLibrary.Context;
using PostManCloneLibrary.Models;

namespace PostManCloneLibrary
{
    public class LogDB : ILogDB, IDisposable
    {
        private readonly LogDbContext _context;

        public LogDB(LogDbContext context)
        {
            _context = context;

            // Ensure the database is created
            _context.Database.EnsureCreated();
        }

        public LogDbContext GetDBContext()
        {
            return _context;
        }

        public void InsertResults(List<Dictionary<string, object>> responses)
        {
            // Generate a GUID for the batch of responses and use the current date/time
            Guid guid = Guid.NewGuid();
            DateTime dateTime = DateTime.UtcNow;

            foreach (var response in responses)
            {
                if (!response.ContainsKey("Name") || !response.ContainsKey("Value"))
                {
                    throw new ArgumentException("Each response must contain both 'Name' and 'Value' keys.");
                }
                // Create one log entry for each response dictionary
                var logEntry = new Response
                {
                    DateTime = dateTime,
                    Name = response.ContainsKey("Name") ? response["Name"].ToString() : null,
                    Value = response.ContainsKey("Value") ? response["Value"].ToString() : null,
                    GUID = guid.ToString()
                };

                _context.LogEntries.Add(logEntry); // Add the log entry
            }

            // Save changes to the database
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

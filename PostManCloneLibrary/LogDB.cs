using PostManCloneLibrary.Context;
using PostManCloneLibrary.Models;

namespace PostManCloneLibrary
{
    public class LogDB : ILogDB, IDisposable
    {
        private readonly LogDbContext _context;
        private bool _disposed = false;

        public LogDB(LogDbContext context)
        {
            _context = context;

            // Ensure the database is created
            _ = _context.Database.EnsureCreated();
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

            foreach (Dictionary<string, object> response in responses)
            {
                foreach (KeyValuePair<string, object> entry in response)
                {
                    // Create a new log entry for each key-value pair
                    Response logEntry = new()
                    {
                        DateTime = dateTime,
                        Name = entry.Key,  // Use the dictionary key as "Name"
                        Value = entry.Value?.ToString(),  // Convert the value to string (handles null values)
                        GUID = guid.ToString()
                    };

                    _ = _context.LogEntries.Add(logEntry); // Add the log entry
                }
            }

            // Save changes to the database
            _ = _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Prevents the finalizer from running
        }

        // Protected implementation of Dispose pattern
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    _context?.Dispose();
                }

                // Dispose unmanaged resources here, if any

                _disposed = true;
            }
        }

        // Destructor to handle cases where Dispose is not called
        ~LogDB()
        {
            Dispose(false);
        }
    }
}

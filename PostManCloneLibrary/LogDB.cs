using Microsoft.Data.Sqlite;

namespace PostManCloneLibrary
{
    public class LogDB : ILogDB, IDisposable
    {
        private readonly string _connectionString;
        private readonly bool _useInMemory;
        private SqliteConnection _connection;

        public LogDB(string dbFilePath = "Logs.db", bool useInMemory = false)
        {
            _useInMemory = useInMemory;

            if (useInMemory)
            {
                // Use an in-memory SQLite database
                _connectionString = "Data Source=:memory:";
            }
            else
            {
                _connectionString = $"Data Source={dbFilePath}";

                // Ensure the file exists if file-based DB is being used
                if (!File.Exists(dbFilePath))
                {
                    File.Create(dbFilePath).Dispose(); // Create the file if it doesn't exist
                }
            }

            // Open connection immediately for in-memory database
            _connection = new SqliteConnection(_connectionString);
            _connection.Open();
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }

        public void InitializeDB()
        {
            // Skip file existence checks for in-memory databases
            string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Log (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Date TEXT,
                Name TEXT,
                Value TEXT,
                GUID TEXT
            );";

            using (var command = new SqliteCommand(createTableQuery, _connection))
            {
                command.ExecuteNonQuery();  // Execute the query to create the table
            }
        }

        // Dispose of the connection to close the database
        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }


}

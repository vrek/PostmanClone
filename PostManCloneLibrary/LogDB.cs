using Microsoft.Data.Sqlite;

namespace PostManCloneLibrary
{
    public class LogDB : ICreateDB
    {
        private string _dbFilePath;
        private string _connectionString;



        public LogDB(string dbFilePath = "Logs.db")
        {
            _dbFilePath = dbFilePath;
            _connectionString = $"Data Source={_dbFilePath}";
        }

        public void InitializeDB()
        {

            if (!File.Exists(_connectionString))
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string createTableQuery = @" CREATE TABLE IF NOT EXISTS Log (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Date TEXT,
                            Thread TEXT,
                            Level TEXT,
                            Logger TEXT,
                            Message TEXT,
                            Exception TEXT
                        );";
                    using (var command = new SqliteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();  // Execute the query to create the table
                    }
                }
            }
        }
    }
}

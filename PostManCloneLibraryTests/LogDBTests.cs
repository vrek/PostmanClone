using Microsoft.Data.Sqlite;

namespace PostManCloneLibrary.Tests
{
    public class LogDBTests()
    {
        [TestMethod]
        public void InitializeDBCreatesTableWhenUsingInMemoryDB()
        {
            // Arrange
            using (var logDB = new LogDB(useInMemory: true))
            {
                // Act
                logDB.InitializeDB();

                // Assert
                using (var command = new SqliteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='Log';", new SqliteConnection(logDB.GetConnectionString())))
                {
                    command.Connection.Open();
                    var result = command.ExecuteScalar();
                    Assert.IsNotNull(result, "The Log table should be created in the in-memory database.");
                }
            }
        }
    }
}
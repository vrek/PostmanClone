using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PostManCloneLibrary.Context;

namespace PostManCloneLibrary.Tests
{
    [TestClass]
    public class LogDbTests
    {
        private LogDbContext _context;
        private SqliteConnection _connection;
        private LogDB _logDb;

        [TestInitialize]
        public void Initialize()
        {

            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<LogDbContext>()
                .UseSqlite(_connection)
                .Options;

            // Initialize the DbContext with in-memory SQLite
            _context = new LogDbContext(options);

            _context.Database.EnsureCreated();
            _logDb = new LogDB(_context);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
            _connection.Close();
        }

        [TestMethod]
        public void InsertResults_ShouldInsertDataIntoDatabase()
        {
            // Arrange
            var responses = new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>
                    {
                        { "Name", "TestName1" },
                        { "Value", "TestValue1" }
                    },
                    new Dictionary<string, object>
                    {
                        { "Name", "TestName2" },
                        { "Value", "TestValue2" }
                    }
                };

            // Act
            _logDb.InsertResults(responses);

            // Assert
            var insertedLogs = _context.LogEntries.ToList();
            Assert.AreEqual(2, insertedLogs.Count);
        }

        [TestMethod]
        public void InsertResults_ShouldInsertDataCorrectlyIntoDatabase()
        {
            // Arrange
            var responses = new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>
                    {
                        { "Name", "TestName1" },
                        { "Value", "TestValue1" }
                    },
                    new Dictionary<string, object>
                    {
                        { "Name", "TestName2" },
                        { "Value", "TestValue2" }
                    }
                };

            // Act
            _logDb.InsertResults(responses);

            // Assert
            var insertedLogs = _context.LogEntries.ToList();

            Assert.AreEqual("TestName1", insertedLogs[0].Name);
            Assert.AreEqual("TestValue1", insertedLogs[0].Value);

            Assert.AreEqual("TestName2", insertedLogs[1].Name);
            Assert.AreEqual("TestValue2", insertedLogs[1].Value);
        }

        [TestMethod]
        public void InsertResultsShouldNotInsertWhenGivenEmptyList()
        {
            var responses = new List<Dictionary<string, object>>();

            _logDb.InsertResults(responses);

            var InsertedLogs = _context.LogEntries.ToList();
            Assert.AreEqual(0, InsertedLogs.Count);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertResults_ShouldThrowExceptionForDataMissingValue()
        {
            // Arrange
            var responses = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>
                {
                    { "Name", "TestName1" }  // Missing Value key
                },
            };
            // Act
            _logDb.InsertResults(responses);

            // Assert
            // No assert needed, as we're expecting an exception to be thrown
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertResults_ShouldThrowExceptionForDataMissingName()
        {
            // Arrange
            var responses = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>
                {
                    { "Value", "ValueName1" }  // Missing Value key
                },
            };
            // Act
            _logDb.InsertResults(responses);

            // Assert
            // No assert needed, as we're expecting an exception to be thrown
        }
    }
}
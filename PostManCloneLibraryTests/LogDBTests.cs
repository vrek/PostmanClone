using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PostManCloneLibrary;
using PostManCloneLibrary.Context;

namespace PostManCloneLibraryTests
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

            DbContextOptions<LogDbContext> options = new DbContextOptionsBuilder<LogDbContext>()
                .UseSqlite(_connection)
                .Options;

            // Initialize the DbContext with in-memory SQLite
            _context = new LogDbContext(options);

            _ = _context.Database.EnsureCreated();
            _logDb = new LogDB(_context);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _ = _context.Database.EnsureDeleted();
            _context.Dispose();
            _connection.Close();
        }

        [TestMethod]
        public void InsertResults_ShouldInsertDataIntoDatabase()
        {
            // Arrange
            List<Dictionary<string, object>> responses =
                [
                    new() {
                        { "Name", "TestName1" },
                        { "Value", "TestValue1" }
                    },
                    new() {
                        { "Name", "TestName2" },
                        { "Value", "TestValue2" }
                    }
                ];

            // Act
            _logDb.InsertResults(responses);

            // Assert
            List<PostManCloneLibrary.Models.Response> insertedLogs = [.. _context.LogEntries];
            Assert.AreEqual(2, insertedLogs.Count);
        }

        [TestMethod]
        public void InsertResults_ShouldInsertDataCorrectlyIntoDatabase()
        {
            // Arrange
            List<Dictionary<string, object>> responses =
                [
                    new() {
                        { "Name", "TestName1" },
                        { "Value", "TestValue1" }
                    },
                    new() {
                        { "Name", "TestName2" },
                        { "Value", "TestValue2" }
                    }
                ];

            // Act
            _logDb.InsertResults(responses);

            // Assert
            List<PostManCloneLibrary.Models.Response> insertedLogs = [.. _context.LogEntries];

            Assert.AreEqual("TestName1", insertedLogs[0].Name);
            Assert.AreEqual("TestValue1", insertedLogs[0].Value);

            Assert.AreEqual("TestName2", insertedLogs[1].Name);
            Assert.AreEqual("TestValue2", insertedLogs[1].Value);
        }

        [TestMethod]
        public void InsertResultsShouldNotInsertWhenGivenEmptyList()
        {
            List<Dictionary<string, object>> responses = [];

            _logDb.InsertResults(responses);

            List<PostManCloneLibrary.Models.Response> InsertedLogs = [.. _context.LogEntries];
            Assert.AreEqual(0, InsertedLogs.Count);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertResults_ShouldThrowExceptionForDataMissingValue()
        {
            // Arrange
            List<Dictionary<string, object>> responses =
            [
                new() {
                    { "Name", "TestName1" }  // Missing Value key
                },
            ];
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
            List<Dictionary<string, object>> responses =
            [
                new() {
                    { "Value", "ValueName1" }  // Missing Value key
                },
            ];
            // Act
            _logDb.InsertResults(responses);

            // Assert
            // No assert needed, as we're expecting an exception to be thrown
        }

        [TestMethod]
        public void InsertResults_ShouldConvertNonStringValues()
        {
            // Arrange
            List<Dictionary<string, object>> responses =
            [
        new() {
            { "Name", "TestName1" },
            { "Value", 12345 }  // Integer instead of string
        },
        new() {
            { "Name", "TestName2" },
            { "Value", true }  // Boolean instead of string
        }
            ];

            // Act
            _logDb.InsertResults(responses);

            // Assert
            List<PostManCloneLibrary.Models.Response> insertedLogs = [.. _context.LogEntries];
            Assert.AreEqual(2, insertedLogs.Count);

            // First log entry should have the integer value converted to string
            Assert.AreEqual("12345", insertedLogs[0].Value);

            // Second log entry should have the boolean value converted to string
            Assert.AreEqual("True", insertedLogs[1].Value);
        }
    }
}
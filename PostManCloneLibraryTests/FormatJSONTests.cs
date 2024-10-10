using PostManCloneLibrary;
using System.Text.Json;


namespace PostManCloneLibraryTests
{
    [TestClass()]
    public class FormatJSONTests
    {

        public static readonly JsonSerializerOptions options = new() { WriteIndented = true };

        [TestMethod()]
        public void GiveAStringReturnsJsonProperlyFormatted()
        {

            // Arrange
            string inputJson = "{\"userId\": 1,\"id\": 1,\"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\", \"body\": \"quia et suscipitnsuscipit recusandae consequuntur expedita et cumnreprehenderit molestiae ut ut quas totamnostrum rerum est autem sunt rem eveniet architecto\"}";
            JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(inputJson);
            string expectedJson = JsonSerializer.Serialize(jsonElement, options);

            //Act
            string result = JsonFormatter.FormatJson(inputJson);

            //Assert
            Assert.AreEqual(expectedJson, result);
        }

        [TestMethod()]
        public void GiveABlankStringReturnsABlankString()
        {

            // Arrange
            string inputJson = "";

            //Act
            string result = JsonFormatter.FormatJson(inputJson);

            //Assert
            Assert.AreEqual(inputJson, result);

        }
        [TestMethod()]
        public void NestedJsonObjectsShouldBeProperlyFormatted()
        {
            //Arrange
            string InputString = "[{\"id\":1,\"name\":\"Tom\",\"sport\":\"football\"},{\"id\":2,\"name\":\"Michael\",\"sport\":\"BasketBall\"},{\"id\":3,\"name\":\"Sammy\",\"sport\":\"Baseball\"}]";
            JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(InputString);
            string expectedJson = JsonSerializer.Serialize(jsonElement, options);
            _ = new JSONValidator();

            //Act
            string result = JsonFormatter.FormatJson(InputString);

            //Assert
            Assert.AreEqual(expectedJson, result);
        }
        [TestMethod()]
        public void MalformedJSONShallThrowException()
        {
            //Arrange
            string InputString = "[{\"id\":1,\"name\":\"Tom\",\"sport\":\"football,id\":2,\"name\":\"Michael\",\"sport\":\"BasketBall\"}{\"id\":3,\"name\":\"Sammy\",\"sport\":\"Baseball\"}]";

            //Act

            //Assert
            _ = Assert.ThrowsException<JsonException>(() => JsonFormatter.FormatJson(InputString));
        }
        [TestMethod()]
        public void WhenStringWithNameNotInDoubleQuotesThrowsException()
        {
            //Arrange
            string InputString = "[{\"id\":1,name:\"Tom\",\"sport\":\"football\"},{\"id\":2,\"name\":\"Michael\",\"sport\":\"BasketBall\"},{\"id\":3,\"name\":\"Sammy\",\"sport\":\"Baseball\"}]";
            JSONValidator validate = new();
            //Act

            //Assert
            _ = Assert.ThrowsException<JsonException>(() => JsonFormatter.FormatJson(InputString));
        }
    }
}
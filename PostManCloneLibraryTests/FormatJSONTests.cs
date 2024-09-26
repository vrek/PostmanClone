using System.Text.Json;


namespace PostManCloneLibrary.Tests
{
    [TestClass()]
    public class FormatJSONTests
    {
        [TestMethod()]
        public void GiveAStringReturnsJsonProperlyFormatted()
        {

            // Arrange
            string inputJson = "{\"userId\": 1,\"id\": 1,\"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\", \"body\": \"quia et suscipitnsuscipit recusandae consequuntur expedita et cumnreprehenderit molestiae ut ut quas totamnostrum rerum est autem sunt rem eveniet architecto\"}";
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(inputJson);
            string expectedJson = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions { WriteIndented = true });

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
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(InputString);
            string expectedJson = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions { WriteIndented = true });
            JSONValidator validate = new();

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
            Assert.ThrowsException<JsonException>(() => JsonFormatter.FormatJson(InputString));
        }
        [TestMethod()]
        public void WhenStringWithNameNotInDoubleQuotesThrowsException()
        {
            //Arrange
            string InputString = "[{\"id\":1,name:\"Tom\",\"sport\":\"football\"},{\"id\":2,\"name\":\"Michael\",\"sport\":\"BasketBall\"},{\"id\":3,\"name\":\"Sammy\",\"sport\":\"Baseball\"}]";
            JSONValidator validate = new();
            //Act

            //Assert
            Assert.ThrowsException<JsonException>(() => JsonFormatter.FormatJson(InputString));
        }
    }
}
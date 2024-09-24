namespace PostManCloneLibrary.Tests
{
    [TestClass()]
    public class JsonParserTests
    {
        [TestMethod()]
        public void JsonStringWith1ObjectReturnsDictionaryWith1Item()
        {
            //Arrange
            string InputString = "{\"id\":1,\"name\":\"Tom\",\"sport\":\"football\"}";

            //Act
            List<Dictionary<string, string>> returnDict = JsonParser.ParseJsonString(InputString);

            //Assert
            Assert.AreEqual(1, returnDict.Count);
        }
        [TestMethod()]
        public void JsonStringWith3ObjectsReturnsDictionaryWith3Item()
        {
            //Arrange
            string InputString = "{{\"id\":1,\"name\":\"Tom\",\"sport\":\"football\"},{\"id\":2,\"name\":\"Michael\",\"sport\":\"BasketBall\"},{\"id\":3,\"name\":\"Sammy\",\"sport\":\"Baseball\"}";

            //Act
            List<Dictionary<string, string>> returnDict = JsonParser.ParseJsonString(InputString);

            //Assert
            Assert.AreEqual(3, returnDict.Count);
        }

    }
}
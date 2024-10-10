using PostManCloneLibrary;

namespace PostManCloneLibraryTests
{
    [TestClass()]
    public class JsonParserTests
    {
        [TestMethod()]
        public void JsonStringWith1ObjectReturnsDictionaryWith1Item()
        {
            // Arrange
            string InputString = "{\"id\":1,\"name\":\"Tom\",\"sport\":\"football\"}";

            // Act
            List<Dictionary<string, object>> returnDict = JsonParser.ParseJsonString(InputString);

            // Assert
            Assert.AreEqual(1, returnDict.Count);
        }


        [TestMethod()]
        public void JsonStringWithEqualSizeObjectsReturnsDictionaryWithEqualSizes()
        {
            // Arrange
            string InputString = "[{\"id\":1,\"name\":\"Tom\",\"sport\":\"football\"},{\"id\":2,\"name\":\"Michael\",\"sport\":\"BasketBall\"},{\"id\":3,\"name\":\"Sammy\",\"sport\":\"Baseball\"}]";

            // Act
            List<Dictionary<string, object>> returnDict = JsonParser.ParseJsonString(InputString);

            // Assert
            Assert.AreEqual(returnDict[0].Count, returnDict[1].Count);
        }


        [TestMethod()]
        public void JsonStringWith3ObjectsReturnsDictionaryWith3Items()
        {
            // Arrange
            string InputString = "[{\"id\":1,\"name\":\"Tom\",\"sport\":\"football\"},{\"id\":2,\"name\":\"Michael\",\"sport\":\"BasketBall\"},{\"id\":3,\"name\":\"Sammy\",\"sport\":\"Baseball\"}]";

            // Act
            List<Dictionary<string, object>> returnDict = JsonParser.ParseJsonString(InputString);

            // Assert
            Assert.AreEqual(3, returnDict.Count);
        }



    }
}
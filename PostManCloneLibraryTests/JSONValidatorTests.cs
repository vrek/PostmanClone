using PostManCloneLibrary;

namespace PostManCloneLibraryTests
{
    [TestClass()]
    public class JSONValidatorTests
    {
        [TestMethod()]
        public void WhenGivenValidJSONStringReturnsTrue()
        {
            string InputString = "{\"userId\": 1,\"id\": 1,\"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\", \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"}";
            _ = new JSONValidator();
            bool result = JSONValidator.ValidateJSON(InputString);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void WhenGivenStringDoesntStartWithCurlyBraceThrowsException()
        {
            string InputString = "\"userId\": 1,\"id\": 1,\"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\", \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"}";
            JSONValidator validate = new();
            _ = Assert.ThrowsException<FormatException>(() => JSONValidator.ValidateJSON(InputString));
        }

        [TestMethod()]
        public void WhenGivenStringDoesntEndWithCurlyBraceThrowsException()
        {
            string InputString = "{\"userId\": 1,\"id\": 1,\"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\", \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"";
            JSONValidator validate = new();
            _ = Assert.ThrowsException<FormatException>(() => JSONValidator.ValidateJSON(InputString));

        }

        [TestMethod()]
        public void WhenStringWithNameNotInDoubleQuotesThrowsException()
        {
            string InputString = "{userId: 1,\"id\": 1,\"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\", \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"}";
            JSONValidator validate = new();
            _ = Assert.ThrowsException<FormatException>(() => JSONValidator.ValidateJSON(InputString));
        }

        [TestMethod()]
        public void NestedJsonObjectsWithSquareBracetsShouldBeTrue()
        {
            //Arrange
            string InputString = "[{\"id\":1,\"name\":\"Tom\",\"sport\":\"football\"},{\"id\":2,\"name\":\"Michael\",\"sport\":\"BasketBall\"},{\"id\":3,\"name\":\"Sammy\",\"sport\":\"Baseball\"}]";
            _ = new JSONValidator();

            //Act
            bool result = JSONValidator.ValidateJSON(InputString);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
﻿namespace PostManCloneLibrary.Tests
{
    [TestClass()]
    public class JSONValidatorTests
    {
        [TestMethod()]
        public void WhenGivenValidJSONStringReturnsTrue()
        {
            string InputString = "{\"userId\": 1,\"id\": 1,\"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\", \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"}";
            JSONValidator validate = new();
            bool result = validate.ValidateJSON(InputString);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void WhenGivenStringDoesntStartWithCurlyBraceThrowsException()
        {
            string InputString = "\"userId\": 1,\"id\": 1,\"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\", \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"}";
            JSONValidator validate = new();
            Assert.ThrowsException<FormatException>(() => validate.ValidateJSON(InputString));
        }

        [TestMethod()]
        public void WhenGivenStringDoesntEndWithCurlyBraceThrowsException()
        {
            string InputString = "{\"userId\": 1,\"id\": 1,\"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\", \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"";
            JSONValidator validate = new();
            Assert.ThrowsException<FormatException>(() => validate.ValidateJSON(InputString));

        }

        [TestMethod()]
        public void WhenStringWithNameNotInDoubleQuotesThrowsException()
        {
            string InputString = "{userId: 1,\"id\": 1,\"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\", \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"}";
            JSONValidator validate = new();
            Assert.ThrowsException<FormatException>(() => validate.ValidateJSON(InputString));
        }

        [TestMethod()]
        public void NestedJsonObjectsWithSquareBracetsShouldBeTrue()
        {
            //Arrange
            string InputString = "[{\"id\":1,\"name\":\"Tom\",\"sport\":\"football\"},{\"id\":2,\"name\":\"Michael\",\"sport\":\"BasketBall\"},{\"id\":3,\"name\":\"Sammy\",\"sport\":\"Baseball\"]";
            JSONValidator validate = new();

            //Act
            bool result = validate.ValidateJSON(InputString);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
using System.Text.Json;


namespace PostManCloneLibrary.Tests
{
    [TestClass()]
    public class IsValidUrlTests
    {

        [TestMethod()]
        public void GivenavalidCOMadressReturnsTrue()
        {
            bool expected = true;
            APIAccess api = new APIAccess();
            string url = @"https://jsonplaceholder.typicode.com/posts/1";

            bool result = api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenaBlankAdressReturnsFalse()
        {
            bool expected = false;
            APIAccess api = new APIAccess();
            string url = @"";

            bool result = api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAHTTPAdressReturnsFalse()
        {
            bool expected = false;
            APIAccess api = new APIAccess();
            string url = @"http://jsonplaceholder.typicode.com/posts/1";

            bool result = api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnIPAdressReturnsFalse()
        {
            bool expected = false;
            APIAccess api = new APIAccess();
            string url = @"127.0.0.1";

            bool result = api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnIPAdressAsHTTPAdReturnsTrue()
        {
            bool expected = true;
            APIAccess api = new APIAccess();
            string url = @"https://127.0.0.1/";

            bool result = api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnHTTPAddressWithoutASchemaReturnsFalse()
        {
            bool expected = false;
            APIAccess api = new APIAccess();
            string url = @"jsonplaceholder.typicode.com/posts/1";

            bool result = api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnHTTPAddressWithoutATLDReturnsFalse()
        {
            bool expected = false;
            APIAccess api = new APIAccess();
            string url = @"http://jsonplaceholder.typicode/posts/1";

            bool result = api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnHTTPAddressWithAFakeTLDReturnsFalse()
        {
            bool expected = false;
            APIAccess api = new APIAccess();
            string url = @"http://jsonplaceholder.faketld/posts/1";

            bool result = api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }
    }
    [TestClass()]
    public class CallAPITests
    {
        [TestMethod()]
        public async Task GivenGetCommandAndValidURLReturnsPosts()
        {
            APIAccess api = new APIAccess();

            string inputJson = "{\"userId\": 1,\"id\": 1,\"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\", \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"}";
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(inputJson);
            string expectedJson = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions { WriteIndented = true });

            string url = @"https://jsonplaceholder.typicode.com/posts/1";
            string result = await api.CallAPI(url);
            Assert.AreEqual(expectedJson, result);
        }

        [TestMethod()]
        public async Task GivenGetCommandAndInvalidURLReturnsErrorCode()
        {
            APIAccess api = new APIAccess();

            string expected = "Error: 521";

            string url = @"https://jsonplaceholder.com/posts/1";
            string result = await api.CallAPI(url);
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass()]
    public class FormatJSONTests
    {
        [TestMethod()]
        public async Task GiveAStringReturnsJsonProperlyFormatted()
        {

            // Arrange
            string inputJson = "{\"userId\": 1,\"id\": 1,\"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\", \"body\": \"quia et suscipitnsuscipit recusandae consequuntur expedita et cumnreprehenderit molestiae ut ut quas totamnostrum rerum est autem sunt rem eveniet architecto\"}";
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(inputJson);
            string expectedJson = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions { WriteIndented = true });

            string result = APIAccess.FormatJson(inputJson);

            Assert.AreEqual(expectedJson, result);
        }
    }
}
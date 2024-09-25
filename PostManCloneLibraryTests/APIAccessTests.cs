using Moq;
using Moq.Protected;
using System.Net;
using System.Text.Json;


namespace PostManCloneLibrary.Tests
{
    [TestClass()]
    public class IsValidUrlTests
    {
        public required Mock<HttpMessageHandler> _mockHttpMessageHandler;
        public required HttpClient _mockClient;
        public required APIAccess _api;

        [TestInitialize]
        public void Setup()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            _mockClient = new HttpClient(_mockHttpMessageHandler.Object);

            _api = new APIAccess(_mockClient);


        }


        [TestMethod()]
        public void GivenavalidCOMadressReturnsTrue()
        {
            //_mockHttpMessageHandler
            //    .Protected()
            //    .Setup<Task<HttpResponseMessage>>(
            //    "SendAsync", // The method we are mocking
            //    ItExpr.IsAny<HttpRequestMessage>(), // Any HttpRequestMessage
            //    ItExpr.IsAny<CancellationToken>()   // Any CancellationToken
            //)
            //    .ReturnsAsync(new HttpResponseMessage
            //    {
            //        StatusCode = HttpStatusCode.OK,
            //        Content = new StringContent("{ 'key': 'value' }")
            //    });

            ////var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            bool expected = true;
            string url = @"https://fakeurl.com";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenBlankAddressReturnsFalse()
        {
            bool expected = false;
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync", // The method we are mocking
                ItExpr.IsAny<HttpRequestMessage>(), // Any HttpRequestMessage
                ItExpr.IsAny<CancellationToken>()   // Any CancellationToken
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ 'key': 'value' }")
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            string url = @"";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAHTTPAdressReturnsFalse()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync", // The method we are mocking
                ItExpr.IsAny<HttpRequestMessage>(), // Any HttpRequestMessage
                ItExpr.IsAny<CancellationToken>()   // Any CancellationToken
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ 'key': 'value' }")
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            bool expected = false;
            string url = @"http://jsonplaceholder.typicode.com/posts/1";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnIPAdressReturnsFalse()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync", // The method we are mocking
                ItExpr.IsAny<HttpRequestMessage>(), // Any HttpRequestMessage
                ItExpr.IsAny<CancellationToken>()   // Any CancellationToken
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ 'key': 'value' }")
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            bool expected = false;
            string url = @"127.0.0.1";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnIPAdressAsHTTPAdReturnsTrue()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync", // The method we are mocking
                ItExpr.IsAny<HttpRequestMessage>(), // Any HttpRequestMessage
                ItExpr.IsAny<CancellationToken>()   // Any CancellationToken
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ 'key': 'value' }")
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);

            bool expected = true;

            string url = @"https://127.0.0.1/";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnHTTPAddressWithoutASchemaReturnsFalse()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync", // The method we are mocking
                ItExpr.IsAny<HttpRequestMessage>(), // Any HttpRequestMessage
                ItExpr.IsAny<CancellationToken>()   // Any CancellationToken
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ 'key': 'value' }")
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            bool expected = false;
            string url = @"jsonplaceholder.typicode.com/posts/1";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnHTTPAddressWithoutATLDReturnsFalse()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync", // The method we are mocking
                ItExpr.IsAny<HttpRequestMessage>(), // Any HttpRequestMessage
                ItExpr.IsAny<CancellationToken>()   // Any CancellationToken
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ 'key': 'value' }")
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            bool expected = false;

            string url = @"http://jsonplaceholder.typicode/posts/1";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnHTTPAddressWithAFakeTLDReturnsFalse()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync", // The method we are mocking
                ItExpr.IsAny<HttpRequestMessage>(), // Any HttpRequestMessage
                ItExpr.IsAny<CancellationToken>()   // Any CancellationToken
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ 'key': 'value' }")
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            bool expected = false;
            string url = @"http://jsonplaceholder.faketld/posts/1";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }
    }
    [TestClass()]
    public class CallAPITests
    {
        public required Mock<HttpMessageHandler> _mockHttpMessageHandler;
        public required HttpClient _mockClient;
        public required APIAccess _api;

        [TestInitialize]
        public void Setup()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            _mockClient = new HttpClient(_mockHttpMessageHandler.Object);

            _api = new APIAccess(_mockClient);
        }

        [TestMethod()]
        public async Task GivenGetCommandAndValidURLReturnsPosts()
        {
            //Arrange
            string inputJson = "{ \"key\": \"value\" }";
            var Expectedjson = APIAccess.FormatJson(inputJson);
            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync", // The method we are mocking
                ItExpr.IsAny<HttpRequestMessage>(), // Any HttpRequestMessage
                ItExpr.IsAny<CancellationToken>()   // Any CancellationToken
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ \"key\": \"value\" }")
                });

            var httpClient = new HttpClient(_mockHttpMessageHandler.Object);

            string url = "http://fakeurl.com/api";
            //Act

            var result = await _api.CallAPI(url);


            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(Expectedjson, result);
        }

        [TestMethod()]
        public async Task GivenPostCommandAndValidURLReturnsGivenPost()
        {
            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync", // The method we are mocking
                ItExpr.IsAny<HttpRequestMessage>(), // Any HttpRequestMessage
                ItExpr.IsAny<CancellationToken>()   // Any CancellationToken
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"Title\": \"This is a title\",\"Body\": \"This is a body\",\"userId\": 3, \"id\": 101}")
                });

            var httpClient = new HttpClient(_mockHttpMessageHandler.Object);


            string inputString = "{\"Title\": \"This is a title\",\"Body\": \"This is a body\",\"userId\": 3}";

            var outputString = "{\"Title\": \"This is a title\",\"Body\": \"This is a body\",\"userId\": 3, \"id\": 101}";
            var outputElement = JsonSerializer.Deserialize<JsonElement>(outputString);

            string outputJson = JsonSerializer.Serialize(outputElement, new JsonSerializerOptions { WriteIndented = true });

            string url = @"http://fakeurl.com/api";
            string result = await _api.CallAPI(url, inputString, HttpAction.POST);
            Assert.AreEqual(outputJson, result);
        }

        [TestMethod()]
        public async Task GivenPutCommandAndValidURLReturnsGivenPost()
        {


            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync", // The method we are mocking
                ItExpr.IsAny<HttpRequestMessage>(), // Any HttpRequestMessage
                ItExpr.IsAny<CancellationToken>()   // Any CancellationToken
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ \"id\": 1, \"Title\": \"This is a title\",\"Body\": \"This is a body\",\"userId\": 1}")
                });

            var httpClient = new HttpClient(_mockHttpMessageHandler.Object);

            string inputString = @"{ ""id"": 1, ""Title"": ""This is a title"", ""Body"": ""This is a body"", ""userId"": 1}";

            var outputString = @"{ ""id"": 1, ""Title"": ""This is a title"",""Body"": ""This is a body"",""userId"": 1}";
            var outputElement = JsonSerializer.Deserialize<JsonElement>(outputString);

            string outputJson = JsonSerializer.Serialize(outputElement, new JsonSerializerOptions { WriteIndented = true });

            string url = @"http://fakeurl.com/api";
            string result = await _api.CallAPI(url, inputString, HttpAction.PUT);
            Assert.AreEqual(outputJson, result);
        }

        [TestMethod()]
        public async Task GivenPatchCommandAndValidURLReturnsGivenPost()
        {

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync", // The method we are mocking
                ItExpr.IsAny<HttpRequestMessage>(), // Any HttpRequestMessage
                ItExpr.IsAny<CancellationToken>()   // Any CancellationToken
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"userId\": 1,\"id\": 1,\"title\": \"This is a title\", \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"}")
                });

            var httpClient = new HttpClient(_mockHttpMessageHandler.Object);

            string inputString = "{\"title\": \"This is a title\"}";

            string outputstring = "{\"userId\": 1,\"id\": 1,\"title\": \"This is a title\", \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"}";
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(outputstring);
            string outputJson = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions { WriteIndented = true });

            string url = @"https://jsonplaceholder.typicode.com/posts/1";
            string result = await _api.CallAPI(url, inputString, HttpAction.PATCH);
            Assert.AreEqual(outputJson, result);
        }

        [TestMethod()]
        public async Task GivenGetCommandAndInvalidURLReturnsErrorCode()
        {
            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync", // The method we are mocking
                ItExpr.IsAny<HttpRequestMessage>(), // Any HttpRequestMessage
                ItExpr.IsAny<CancellationToken>()   // Any CancellationToken
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = (HttpStatusCode)521,
                    Content = new StringContent("{ 'key': 'value' }")
                });

            var httpClient = new HttpClient(_mockHttpMessageHandler.Object);

            string expected = "Error: 521";

            string url = @"https://fakeurl.com/noapi";
            string result = await _api.CallAPI(url);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public async Task GivenDeleteCommandAndValidURLReturnsPosts()
        {

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync", // The method we are mocking
                ItExpr.IsAny<HttpRequestMessage>(), // Any HttpRequestMessage
                ItExpr.IsAny<CancellationToken>()   // Any CancellationToken
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{}")
                });

            var httpClient = new HttpClient(_mockHttpMessageHandler.Object);

            string expectedJson = "{}";

            string url = @"https://jsonplaceholder.typicode.com/posts/1";
            string result = await _api.CallAPI(url, "", HttpAction.DELETE);
            Assert.AreEqual(expectedJson, result);
        }
    }

    [TestClass()]
    public class FormatJSONTests
    {
        [TestMethod()]
        public Task GiveAStringReturnsJsonProperlyFormatted()
        {

            // Arrange
            string inputJson = "{\"userId\": 1,\"id\": 1,\"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\", \"body\": \"quia et suscipitnsuscipit recusandae consequuntur expedita et cumnreprehenderit molestiae ut ut quas totamnostrum rerum est autem sunt rem eveniet architecto\"}";
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(inputJson);
            string expectedJson = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions { WriteIndented = true });

            string result = APIAccess.FormatJson(inputJson);

            Assert.AreEqual(expectedJson, result);
            return Task.CompletedTask;
        }
    }
}
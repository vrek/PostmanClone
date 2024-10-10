using log4net;
using Moq;
using Moq.Protected;
using PostManCloneLibrary;
using System.Net;


namespace PostManCloneLibraryTests
{
    [TestClass()]
    public class IsValidUrlTests
    {
        public required Mock<HttpMessageHandler> _mockHttpMessageHandler;
        public required Mock<ILog> _mockLogger;
        public required HttpClient _mockClient;
        public required APIAccess _api;

        [TestInitialize]
        public void Setup()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            _mockClient = new HttpClient(_mockHttpMessageHandler.Object);
            _mockLogger = new Mock<ILog>();
            _api = new APIAccess(_mockClient);


        }


        [TestMethod()]
        public void GivenavalidCOMadressReturnsTrue()
        {

            bool expected = true;
            string url = @"https://fakeurl.com";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenBlankAddressReturnsFalse()
        {
            bool expected = false;
            Mock<HttpMessageHandler> mockHttpMessageHandler = new();
            _ = mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ 'key': 'value' }")
                });
            _ = new
            HttpClient(mockHttpMessageHandler.Object);
            string url = @"";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAHTTPAdressReturnsFalse()
        {
            Mock<HttpMessageHandler> mockHttpMessageHandler = new();
            _ = mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ 'key': 'value' }")
                });
            _ = new
            HttpClient(mockHttpMessageHandler.Object);
            bool expected = false;
            string url = @"http://jsonplaceholder.typicode.com/posts/1";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnIPAdressReturnsFalse()
        {
            Mock<HttpMessageHandler> mockHttpMessageHandler = new();
            _ = mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ 'key': 'value' }")
                });
            _ = new
            HttpClient(mockHttpMessageHandler.Object);
            bool expected = false;
            string url = @"127.0.0.1";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnIPAdressAsHTTPAdReturnsTrue()
        {
            Mock<HttpMessageHandler> mockHttpMessageHandler = new();
            _ = mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ 'key': 'value' }")
                });
            _ = new
            HttpClient(mockHttpMessageHandler.Object);

            bool expected = true;

            string url = @"https://127.0.0.1/";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnHTTPAddressWithoutASchemaReturnsFalse()
        {
            Mock<HttpMessageHandler> mockHttpMessageHandler = new();
            _ = mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ 'key': 'value' }")
                });
            _ = new
            HttpClient(mockHttpMessageHandler.Object);
            bool expected = false;
            string url = @"jsonplaceholder.typicode.com/posts/1";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnHTTPAddressWithoutATLDReturnsFalse()
        {
            Mock<HttpMessageHandler> mockHttpMessageHandler = new();
            _ = mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ 'key': 'value' }")
                });
            _ = new
            HttpClient(mockHttpMessageHandler.Object);
            bool expected = false;

            string url = @"http://jsonplaceholder.typicode/posts/1";

            bool result = _api.IsValidUrl(url);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void GivenAnHTTPAddressWithAFakeTLDReturnsFalse()
        {
            Mock<HttpMessageHandler> mockHttpMessageHandler = new();
            _ = mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ 'key': 'value' }")
                });
            _ = new
            HttpClient(mockHttpMessageHandler.Object);
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
        public required Mock<ILog> _mockLogger;
        public required APIAccess _api;

        [TestInitialize]
        public void Setup()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            _mockClient = new HttpClient(_mockHttpMessageHandler.Object);
            _mockLogger = new Mock<ILog>();
            _api = new APIAccess(_mockClient);
        }

        [TestMethod()]
        public async Task GivenGetCommandAndValidURLReturnsPosts()
        {
            //Arrange
            string inputJson = "{ \"key\": \"value\" }";
            _ = _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ \"key\": \"value\" }")
                });
            _ = new
            HttpClient(_mockHttpMessageHandler.Object);

            string url = "http://fakeurl.com/api";
            //Act

            string result = await _api.CallAPI(url, _mockLogger.Object);


            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(inputJson, result);
        }

        [TestMethod()]
        public async Task GivenPostCommandAndValidURLReturnsGivenPost()
        {
            _ = _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"Title\": \"This is a title\",\"Body\": \"This is a body\",\"userId\": 3, \"id\": 101}")
                });
            _ = new
            HttpClient(_mockHttpMessageHandler.Object);


            string inputString = "{\"Title\": \"This is a title\",\"Body\": \"This is a body\",\"userId\": 3}";

            string outputString = "{\"Title\": \"This is a title\",\"Body\": \"This is a body\",\"userId\": 3, \"id\": 101}";


            string url = @"http://fakeurl.com/api";
            string result = await _api.CallAPI(url, _mockLogger.Object, inputString, HttpAction.POST);
            Assert.AreEqual(outputString, result);
        }

        [TestMethod()]
        public async Task GivenPutCommandAndValidURLReturnsGivenPost()
        {


            _ = _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ \"id\": 1, \"Title\": \"This is a title\",\"Body\": \"This is a body\",\"userId\": 1}")
                });
            _ = new
            HttpClient(_mockHttpMessageHandler.Object);

            string inputString = @"{ ""id"": 1, ""Title"": ""This is a title"", ""Body"": ""This is a body"", ""userId"": 1}";

            string outputString = @"{ ""id"": 1, ""Title"": ""This is a title"",""Body"": ""This is a body"",""userId"": 1}";


            string url = @"http://fakeurl.com/api";
            string result = await _api.CallAPI(url, _mockLogger.Object, inputString, HttpAction.PUT);
            Assert.AreEqual(outputString, result);
        }

        [TestMethod()]
        public async Task GivenPatchCommandAndValidURLReturnsGivenPost()
        {

            _ = _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"userId\": 1,\"id\": 1,\"title\": \"This is a title\", \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"}")
                });
            _ = new
            HttpClient(_mockHttpMessageHandler.Object);

            string inputString = "{\"title\": \"This is a title\"}";

            string outputstring = "{\"userId\": 1,\"id\": 1,\"title\": \"This is a title\", \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"}";


            string url = @"https://jsonplaceholder.typicode.com/posts/1";
            string result = await _api.CallAPI(url, _mockLogger.Object, inputString, HttpAction.PATCH);
            Assert.AreEqual(outputstring, result);
        }

        [TestMethod()]
        public async Task GivenGetCommandAndInvalidURLReturnsErrorCode()
        {
            _ = _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = (HttpStatusCode)521,
                    Content = new StringContent("{ 'key': 'value' }")
                });
            _ = new
            HttpClient(_mockHttpMessageHandler.Object);

            string expected = "Error: 521";

            string url = @"https://fakeurl.com/noapi";
            string result = await _api.CallAPI(url, _mockLogger.Object);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public async Task GivenDeleteCommandAndValidURLReturnsPosts()
        {

            _ = _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{}")
                });
            _ = new
            HttpClient(_mockHttpMessageHandler.Object);

            string expectedJson = "{}";

            string url = @"https://jsonplaceholder.typicode.com/posts/1";
            string result = await _api.CallAPI(url: url, _log: _mockLogger.Object, action: HttpAction.DELETE);
            Assert.AreEqual(expectedJson, result);
        }
    }
}
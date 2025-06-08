using System.Net;

namespace GetNextNumber.Tests
{
    public partial class NumberService_Tests
    {
        //chat GPT4o
        public class MockHttpMessageHandler(string responseContent) : HttpMessageHandler
        {
            private readonly string _responseContent = responseContent;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(_responseContent)
                };
                return Task.FromResult(response);
            }
        }
    }
}

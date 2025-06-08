using GetNextNumber.Services;
using GetNextNumber.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace GetNextNumber.Tests
{
    public partial class NumberService_Tests
    {
        [Fact]
        public async Task GetNextNumberAsync__Should_Return_SuccessTrue()
        {
            string fakeResponse = @"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <GetNextNumberResponse xmlns=""http://tempuri.org/"">
                      <GetNextNumberResult>100</GetNextNumberResult>
                    </GetNextNumberResponse>
                  </soap:Body>
                </soap:Envelope>";

            var handlerMock = new MockHttpMessageHandler(fakeResponse);
            var httpClient = new HttpClient(handlerMock);
            var requestService = new RequestService(httpClient);
            var numberService = new NumberService(requestService);

            var result = await numberService.GetNextNumberAsync("TEST");

            Assert.True(result.Success);
            Assert.Equal("100", result.Data);
        }
    }
}

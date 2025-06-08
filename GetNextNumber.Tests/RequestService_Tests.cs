using GetNextNumber.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GetNextNumber.Tests.NumberService_Tests;

namespace GetNextNumber.Tests
{
    public class RequestService_Tests
    {
        [Fact]
        public async Task SendRequestAsync_Should_Return_SuccessTrue()
        {
            var fakeResponse = "<soap:Envelope><soap:Body><Message>OK</Message></soap:Body></soap:Envelope>";
            var handler = new MockHttpMessageHandler(fakeResponse);
            var httpClient = new HttpClient(handler);
            var requestService = new RequestService(httpClient);

            var result = await requestService.SendRequestAsync("<test>xml</test>", "http://tempuri.org/SomeAction");

            Assert.True(result.Success);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(fakeResponse, result.Data);
        }

    }
}

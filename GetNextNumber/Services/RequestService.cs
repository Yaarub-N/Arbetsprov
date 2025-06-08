using GetNextNumber.Interfaces;
using GetNextNumber.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GetNextNumber.Services
{
    public class RequestService(HttpClient httpClient) : IRequestService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<BaseResponseResult<string>> SendRequestAsync(string xml, string action)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "http://rid.validering.infosolutions.se/numberservice.asmx")
                {
                    Content = new StringContent(xml, Encoding.UTF8, "text/xml")
                };

                request.Headers.Add("SOAPAction", $"\"{action}\"");

                var response = await _httpClient.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new BaseResponseResult<string>
                    {
                        Message = $"HTTP Error: {response.StatusCode}",
                        StatusCode = (int)response.StatusCode,
                        Success = false
                    };
                }

                return new BaseResponseResult<string>
                {
                    Data = result,
                    StatusCode = (int)response.StatusCode,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseResult<string>
                {
                    Message = ex.Message,
                    StatusCode = 500,
                    Success = false
                };
            }
        }
    }
}

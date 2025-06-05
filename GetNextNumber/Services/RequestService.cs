using System.Text;

namespace GetNextNumber.Services;

public class RequestService(HttpClient httpClient) : IRequestService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<string> SendRequestAsync(string xml, string action)
    {
        var request = new HttpRequestMessage(HttpMethod.Post,"http://rid.validering.infosolutions.se/numberservice.asmx")
        {
            Content = new StringContent(xml, Encoding.UTF8, "text/xml")
        };

        request.Headers.Add("SOAPAction", $"\"{action}\"");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}   


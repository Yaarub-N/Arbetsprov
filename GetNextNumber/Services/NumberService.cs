using GetNextNumber.Extensions;
using GetNextNumber.Interfaces;
using GetNextNumber.Models;
namespace GetNextNumber.Services;

public class NumberService(IRequestService requestService) : INumberService
{
    private readonly IRequestService _requestService = requestService;

    public async Task<BaseResponseResult<string>> GetNextNumberAsync(string number)
    {
        var xmlRequest = $@"<?xml version=""1.0"" encoding=""utf-8""?>
        <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
        <soap:Body>
        <GetNextNumber xmlns=""http://tempuri.org/"">
        <numberseriescode>{number}</numberseriescode>
        </GetNextNumber>
        </soap:Body>
        </soap:Envelope>";

        try
        {
            var responseXml = await _requestService.SendRequestAsync(xmlRequest, "http://tempuri.org/GetNextNumber");
            Console.WriteLine(responseXml);
            var envelope = XmlExtensions.DeserializeXml<Envelope>(responseXml.Data!);
            var result = envelope?.Data;

            if (result == null)
            {
                return new BaseResponseResult<string>
                {
                    Success = false,
                    Message = "Deserialization failed",
                    StatusCode = 500
                };
            }
            else
                return new BaseResponseResult<string> { Data = result.Body!.Content!.GetNextNumberResult, Success = true, StatusCode = 200 };
        }
        catch( Exception ex)
        {
            return new BaseResponseResult<string> { Success = true, StatusCode = 200, Message=ex.Message };
        }
    }
}
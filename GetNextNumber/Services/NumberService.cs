using GetNextNumber.Extensions;
using GetNextNumber.Models;
namespace GetNextNumber.Services;

public class NumberService(IRequestService requestService) : INumberService
{
    private readonly IRequestService _requestService = requestService;

    public async Task<string> GetNextNumberAsync(string number)
    {
        var xmlRequest = $@"<?xml version=""1.0"" encoding=""utf-8""?>
        <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
        <soap:Body>
        <GetNextNumber xmlns=""http://tempuri.org/"">
        <numberseriescode>{number}</numberseriescode>
        </GetNextNumber>
        </soap:Body>
        </soap:Envelope>";


        var responseXml = await _requestService.SendRequestAsync(xmlRequest,"http://tempuri.org/GetNextNumber");
        Console.WriteLine(responseXml);
        var envelope = XmlExtensions.DeserializeXml<Envelope>(responseXml);
        return envelope?.Body?.Content?.GetNextNumberResult ?? throw new Exception("Fel vid tolkning av SOAP-svar.");


    }
}
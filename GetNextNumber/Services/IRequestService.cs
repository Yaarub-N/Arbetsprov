
namespace GetNextNumber.Services;

public interface IRequestService
{

    Task<string> SendRequestAsync(string xml, string action);
}

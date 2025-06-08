using GetNextNumber.Models;

namespace GetNextNumber.Interfaces;

public interface IRequestService
{
    Task<BaseResponseResult<string>> SendRequestAsync(string xml, string action);
}

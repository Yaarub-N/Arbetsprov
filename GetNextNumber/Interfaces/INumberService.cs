using GetNextNumber.Models;

namespace GetNextNumber.Interfaces;

public interface INumberService
{
    Task<BaseResponseResult<string>> GetNextNumberAsync(string number);
}

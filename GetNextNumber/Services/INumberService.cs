
namespace GetNextNumber.Services;

public interface INumberService
{
    Task<string> GetNextNumberAsync(string seriesCode);
}

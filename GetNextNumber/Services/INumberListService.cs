
namespace GetNextNumber.Services;

public interface INumberListService
{
    IEnumerable<string> GenerateNumberList(int startNumber, int count = 100);
}

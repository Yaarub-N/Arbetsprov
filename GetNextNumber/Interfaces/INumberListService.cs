namespace GetNextNumber.Interfaces;

public interface INumberListService
{
    IEnumerable<string> GenerateNumberList(int startNumber, int count = 100);
}

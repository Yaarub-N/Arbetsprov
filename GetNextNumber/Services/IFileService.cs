
namespace GetNextNumber.Services;

public interface IFileService 
{
    Task SaveToFileAsync(IEnumerable<string> lines, string path);
}

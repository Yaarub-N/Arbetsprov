using GetNextNumber.Models;

namespace GetNextNumber.Interfaces;

public interface IFileService 
{
    Task<BaseResponseResult> SaveToFileAsync(IEnumerable<string> lines, string path);
}

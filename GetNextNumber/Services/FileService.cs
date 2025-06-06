using System.Text;

namespace GetNextNumber.Services;

public class FileService : IFileService
{
    public async Task SaveToFileAsync(IEnumerable<string> lines, string path)
    {
        using var writer = new StreamWriter(path, append: true, encoding: Encoding.UTF8);
        foreach (var line in lines)
        {
            await writer.WriteLineAsync(line);
        }
    }
}

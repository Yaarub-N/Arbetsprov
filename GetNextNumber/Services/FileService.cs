using GetNextNumber.Interfaces;
using GetNextNumber.Models;
using System.Text;

namespace GetNextNumber.Services;

public class FileService : IFileService
{
    public async Task <BaseResponseResult>SaveToFileAsync(IEnumerable<string> lines, string path)
    {
        try
        {
            using var writer = new StreamWriter(path, append: true, encoding: Encoding.UTF8);
            foreach (var line in lines)
            {
                await writer.WriteLineAsync(line);
            }
            return new BaseResponseResult {  Success = true, StatusCode = 200, Message= "File saved successfully." };
        }
       catch(Exception ex)
        {
            return new BaseResponseResult { Message=ex.Message,Success=false,StatusCode=500};
        }
    }
}

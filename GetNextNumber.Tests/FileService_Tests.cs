using GetNextNumber.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace GetNextNumber.Tests
{
    public class FileService_Tests
    {
        [Fact]
        public async Task SaveToFileAsync_WritesCorrectly()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test.txt");
            var fileService = new FileService();
            var lines = new[] { "Test","Test2" };

            var result = await fileService.SaveToFileAsync(lines, path);

            Assert.True(result.Success);
            Assert.Equal(200, result.StatusCode);
            
            File.Delete(path); 
        }
    }
}

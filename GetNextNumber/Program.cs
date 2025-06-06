using GetNextNumber.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddHttpClient<IRequestService, RequestService>();
services.AddTransient<INumberService, NumberService>();
services.AddTransient<INumberListService, NumberListService>();
services.AddTransient<IFileService, FileService>();

var serviceProvider = services.BuildServiceProvider();

var numberService = serviceProvider.GetRequiredService<INumberService>();
var listService = serviceProvider.GetRequiredService<INumberListService>();
var fileService = serviceProvider.GetRequiredService<IFileService>();

try
{
    var number = await numberService.GetNextNumberAsync("TEST");
    Console.WriteLine(number);

    if (!int.TryParse(number, out int start))
    {
        Console.WriteLine("Ogiltigt heltal.");
        return;
    }
    var lines = listService.GenerateNumberList(start).ToList();
    foreach (var line in lines)
    {
        Console.WriteLine(line);
    }
    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
    await fileService.SaveToFileAsync(lines, path);

    Console.WriteLine($" Resultat sparat i: {path}");
}
catch (Exception ex)
{
    Console.WriteLine($"Ett fel inträffade: {ex.Message}");
}

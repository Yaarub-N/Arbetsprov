using GetNextNumber.Interfaces;

namespace GetNextNumber.App;

public class ApplicationRunner(INumberService numberService, INumberListService listService, IFileService fileService)
{
    private readonly INumberService _numberService = numberService;
    private readonly INumberListService _listService = listService;
    private readonly IFileService _fileService = fileService;

    public async Task RunAsync()
    {
        try
        {
            var number = await _numberService.GetNextNumberAsync("TEST");
            Console.WriteLine(number);

            if (!int.TryParse(number.Data, out int start))
            {
                Console.WriteLine("Ogiltigt heltal.");
                return;
            }

            var lines = _listService.GenerateNumberList(start).ToList();

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
            await _fileService.SaveToFileAsync(lines, path);

            Console.WriteLine($" Resultat sparat i: {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Ett fel inträffade: {ex.Message}");
        }
    }
}

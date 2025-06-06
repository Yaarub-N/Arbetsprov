using GetNextNumber;
using GetNextNumber.App;
using GetNextNumber.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddHttpClient<IRequestService, RequestService>();
services.AddTransient<INumberService, NumberService>();
services.AddTransient<INumberListService, NumberListService>();
services.AddTransient<IFileService, FileService>();
services.AddTransient<ApplicationRunner>();

var provider = services.BuildServiceProvider();

var app = provider.GetRequiredService<ApplicationRunner>();
await app.RunAsync();

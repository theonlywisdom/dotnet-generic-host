using ImageService;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices((hostContext, services) =>
{
    services.AddHostedService<Worker>();
});

var host = builder.Build();
host.Run();

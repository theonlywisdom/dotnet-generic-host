using ImageService;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices((hostContext, services) =>
{
    services.AddHostedService<Worker>()
    .AddHostedService<ImageFileWatcher>();
});

var host = builder.Build();
host.Run();

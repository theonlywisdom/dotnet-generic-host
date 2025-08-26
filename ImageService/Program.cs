using ImageService;

var builder = Host.CreateDefaultBuilder(args);
builder
.ConfigureAppConfiguration((hostContex, configBuilder) =>
{
    configBuilder.AddEnvironmentVariables(prefix: "ImageService_");
})
.ConfigureServices((hostContext, services) =>
{
    services.AddHostedService<ImageFileWatcher>();
});

var host = builder.Build();
host.Run();

using ImageService;

var builder = Host.CreateDefaultBuilder(args);
builder
.ConfigureAppConfiguration((hostContex, configBuilder) =>
{
    configBuilder.Sources.Clear();

    IHostEnvironment env = hostContex.HostingEnvironment;
    configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
    configBuilder.AddEnvironmentVariables(prefix: "ImageService_");
})
.ConfigureServices((hostContext, services) =>
{
    services.AddHostedService<ImageFileWatcher>();
});

var host = builder.Build();
host.Run();

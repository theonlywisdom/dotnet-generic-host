using ImageService;
using ImageService.Configuration;

var builder = Host.CreateDefaultBuilder(args);
builder
.ConfigureAppConfiguration((hostContex, configBuilder)
=> configBuilder.AddEnvironmentVariables(prefix: "ImageService_"))
.ConfigureServices((hostContext, services)
=> services.AddHostedService<ImageFileWatcher>()
    .Configure<ImageConfig>(hostContext.Configuration.GetSection(nameof(ImageConfig))));

var host = builder.Build();
host.Run();

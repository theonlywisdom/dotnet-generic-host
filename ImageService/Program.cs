using ImageLibrary.DependencyInjection;

var builder = Host.CreateDefaultBuilder(args);
builder
.ConfigureAppConfiguration((hostContex, configBuilder)
=> configBuilder.AddEnvironmentVariables(prefix: "ImageService_"))
.ConfigureServices((hostContext, services)
=>
{
    services.AddHostedService<ImageFileWatcher>()
        .AddImageLibrary(
        hostContext.Configuration.GetSection(nameof(ImageConfig)),
        new ImageConfig
        {
            CompressionLevel = 0.2m
        },
        thumbnailSizeConfig =>
        {
            thumbnailSizeConfig.FilePrefix = "th-";
        });
});

var host = builder.Build();
host.Run();

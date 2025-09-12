var builder = Host.CreateDefaultBuilder(args);
builder
.ConfigureAppConfiguration((hostContex, configBuilder)
=> configBuilder.AddEnvironmentVariables(prefix: "ImageService_"))
.ConfigureServices((hostContext, services)
=>
{
    services.AddHostedService<ImageFileWatcher>()
        .AddSingleton<IThumbnailProcessor, ThumbnailProcessor>();
    var config = hostContext.Configuration;

    services.AddOptions<ImageConfig>()
        .Configure(imageConfig =>
        {
            imageConfig.CompressionLevel = 0.99m;
        })
        .Bind(config.GetSection(nameof(ImageConfig)));

    services.Configure<ImageSizeConfig>(ImageSizeConfig.Thumbnail, config.GetSection("ImageConfig:Thumbnail"));
    services.Configure<ImageSizeConfig>(ImageSizeConfig.Medium, config.GetSection("ImageConfig:Medium"));
    services.Configure<ImageSizeConfig>(ImageSizeConfig.Large, config.GetSection("ImageConfig:Large"));
});

var host = builder.Build();
host.Run();

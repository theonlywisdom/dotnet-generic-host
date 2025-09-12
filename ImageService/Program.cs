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

    services.Configure<ImageConfig>(config.GetSection(nameof(ImageConfig)));
    services.Configure<ImageConfig>(ImageSizeConfig.Thumbnail, config.GetSection("ImageConfig:Thumbnail"));
    services.Configure<ImageConfig>(ImageSizeConfig.Medium, config.GetSection("ImageConfig:Medium"));
    services.Configure<ImageConfig>(ImageSizeConfig.Large, config.GetSection("ImageConfig:Large"));
});

var host = builder.Build();
host.Run();

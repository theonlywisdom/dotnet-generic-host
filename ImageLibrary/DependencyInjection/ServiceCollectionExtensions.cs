namespace ImageLibrary.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddImageLibrary(this IServiceCollection services, IConfiguration configurationSection, ImageConfig defaultImageConfig, Action<ImageSizeConfig> configureThumbnailSize)
    {
        services.AddSingleton<IThumbnailProcessor, ThumbnailProcessor>();

        services.AddOptions<ImageConfig>()
            .Configure(imageConfig  =>
            {
                imageConfig.CompressionLevel = defaultImageConfig.CompressionLevel;
            })
            .Bind(configurationSection)
            .Validate(
            imageConfig => imageConfig.CompressionLevel > 0,
            "Compression should be positive")
            .Validate(
            imageConfig => imageConfig.CompressionLevel <= 1,
            "Compression should be less than 1");

        services.AddOptions<ImageSizeConfig>(ImageSizeConfig.Thumbnail)
            .Configure(configureThumbnailSize)
            .Bind(configurationSection.GetSection(ImageSizeConfig.Thumbnail));

        services.Configure<ImageSizeConfig>(ImageSizeConfig.Medium, configurationSection.GetSection(ImageSizeConfig.Medium));
        services.Configure<ImageSizeConfig>(ImageSizeConfig.Large, configurationSection.GetSection(ImageSizeConfig.Large));
    }
}

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
            .ValidateDataAnnotations();

        services.AddOptions<ImageSizeConfig>(ImageSizeConfig.Thumbnail)
            .Configure(configureThumbnailSize)
            .Bind(configurationSection.GetSection(ImageSizeConfig.Thumbnail))
            .ValidateDataAnnotations()
            .Validate(
            imageSizeConfig => imageSizeConfig.Width <= 96, "Thumbnail must be 96px or smaller");

        services.Configure<ImageSizeConfig>(ImageSizeConfig.Medium, configurationSection.GetSection(ImageSizeConfig.Medium));
        services.Configure<ImageSizeConfig>(ImageSizeConfig.Large, configurationSection.GetSection(ImageSizeConfig.Large));
    }
}

namespace ImageLibrary.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddImageLibrary(this IServiceCollection services, IConfiguration configurationSection)
    {
        services.AddSingleton<IThumbnailProcessor, ThumbnailProcessor>();

        services.AddOptions<ImageConfig>()
            .Configure(imageConfig =>
            {
                imageConfig.CompressionLevel = 0.99m;
            })
            .Bind(configurationSection);

        services.AddOptions<ImageSizeConfig>(ImageSizeConfig.Thumbnail)
            .Configure(thumbnailSizeConfig =>
            {
                thumbnailSizeConfig.FilePrefix = "thumb-";
            })
            .Bind(configurationSection.GetSection(ImageSizeConfig.Thumbnail));

        services.Configure<ImageSizeConfig>(ImageSizeConfig.Medium, configurationSection.GetSection(ImageSizeConfig.Medium));
        services.Configure<ImageSizeConfig>(ImageSizeConfig.Large, configurationSection.GetSection(ImageSizeConfig.Large));
    }
}

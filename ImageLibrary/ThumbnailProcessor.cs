namespace ImageLibrary;

public class ThumbnailProcessor : IThumbnailProcessor
{
    private readonly ILogger<ThumbnailProcessor> _logger;
    private readonly ImageConfig _imageConfig;
    private readonly ImageSizeConfig _thumbnailSizeConfig;

    public ThumbnailProcessor(
        ILogger<ThumbnailProcessor> logger,
        IOptions<ImageConfig> imageOptionsConfig,
        IOptionsMonitor<ImageSizeConfig> imageSizeConfigOptions)
    {
        _logger = logger;
        _imageConfig = imageOptionsConfig.Value;
        _thumbnailSizeConfig = imageSizeConfigOptions.Get(ImageSizeConfig.Thumbnail);
        imageSizeConfigOptions.OnChange((thumbnailSizeConfig, name) =>
        {
            if (name == ImageSizeConfig.Thumbnail)
            {
                _logger.LogInformation("** Thumbnail Image Config Changed **\n\t" +
                "File Prefix: {FilePrefix}\n\t " +
                "Width: {Width}", thumbnailSizeConfig.Width, thumbnailSizeConfig.FilePrefix);
            }
        });
    }

    public void ProcessImage(string imagePath)
    {
        _logger.LogInformation("***** Process Image {imagePath}*****", imagePath);
        _logger.LogInformation("Compression Level : {CompressionLevel}", _imageConfig.CompressionLevel);
        _logger.LogInformation("Output Path : {OutputPath}", _imageConfig.OutputPath);
        _logger.LogInformation("Thumbnail Width  : {Width}", _thumbnailSizeConfig.Width);
        _logger.LogInformation("Thumbnail FilePrefix : {FilePrefix}", _thumbnailSizeConfig.FilePrefix);
    }
}

public interface IThumbnailProcessor
{
    void ProcessImage(string imagePath);
}
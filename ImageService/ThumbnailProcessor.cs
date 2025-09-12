namespace ImageService;

public class ThumbnailProcessor(
    ILogger<ThumbnailProcessor> logger, 
    IOptions<ImageConfig> imageOptionsConfig,
    IOptionsMonitor<ImageSizeConfig> imageSizeConfigOptions) 
    : IThumbnailProcessor
{
    private readonly ILogger<ThumbnailProcessor> _logger = logger;
    private readonly ImageConfig _imageConfig = imageOptionsConfig.Value;
    private readonly ImageSizeConfig _thumbnailSizeConfig = imageSizeConfigOptions.Get(ImageSizeConfig.Thumbnail);

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
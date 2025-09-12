namespace ImageService;

public class ThumbnailProcessor(ILogger<ThumbnailProcessor> logger, IOptions<ImageConfig> imageOptionsConfig) : IThumbnailProcessor
{
    private readonly ILogger<ThumbnailProcessor> _logger = logger;
    private readonly ImageConfig _imageConfig = imageOptionsConfig.Value;

    public void ProcessImage(string imagePath)
    {
        _logger.LogInformation("***** Process Image {imagePath}*****", imagePath);
        _logger.LogInformation("Compression Level : {CompressionLevel}", _imageConfig.CompressionLevel);
        _logger.LogInformation("Output Path : {OutputPath}", _imageConfig.OutputPath);
    }
}

public interface IThumbnailProcessor
{
    void ProcessImage(string imagePath);
}
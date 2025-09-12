namespace ImageService.Configuration;

public class ImageSizeConfig {
    public const string Thumbnail = nameof(Thumbnail);
    public const string Medium = nameof(Medium);
    public const string Large = nameof(Large);

    public int Width { get; set; }
    public string FilePrefix { get; set; } = string.Empty;
    public string WaterMarkText { get; set; } = string.Empty;
}

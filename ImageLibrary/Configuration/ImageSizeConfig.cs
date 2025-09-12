namespace ImageLibrary.Configuration;

public class ImageSizeConfig {
    public const string Thumbnail = nameof(Thumbnail);
    public const string Medium = nameof(Medium);
    public const string Large = nameof(Large);

    [Range(32, 1024, ErrorMessage ="Width is out of range")]
    public int Width { get; set; }
    public string FilePrefix { get; set; } = string.Empty;
    public string WaterMarkText { get; set; } = string.Empty;
}

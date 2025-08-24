namespace ImageConsoleApp;

public class ImageConfig
{
    public ImageSizeConfig Thumbnail { get; set; }
    public ImageSizeConfig Medium { get; set; }
    public ImageSizeConfig Large { get; set; }
    public decimal CompressionLevel { get; set; }
}
public class ImageSizeConfig
{
    public int Width { get; set; }
    public string FilePrefix { get; set; }
    public string WaterMarkText { get; set; }

}

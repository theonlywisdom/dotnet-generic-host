using System.ComponentModel.DataAnnotations;

namespace ImageLibrary.Configuration;

public class ImageConfig
{
    [Range(0, 1, ErrorMessage ="Compression must be between 0 to 1")]
    public decimal CompressionLevel { get; set; }
    public string OutputPath { get; set; } = string.Empty;
}

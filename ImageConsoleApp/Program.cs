namespace ImageConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        var switchMappings = new Dictionary<string, string>
        {
            { "-tw", "thumbnail:Width" },
            { "-tp", "thumbnail:FilePrefix" },
            { "-mw", "medium:Width" },
            { "-mp", "medium:FilePrefix" },
            { "-lw", "large:Width" },
            { "-lp", "large:FilePrefix" },
            { "-wt", "watermarkText" },
            { "-cl", "compressionLevel" }
        };

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .AddCommandLine(args,switchMappings)
            .Build();

        Console.WriteLine("***** Process Image *****");
        Console.WriteLine($" Processing: {args[0]}");

        IConfiguration thumbnailConfig = configuration
            .GetSection(nameof(Thumbnail));
        ProcessImage(nameof(Thumbnail), thumbnailConfig);

        IConfiguration mediumConfig = configuration
            .GetSection(nameof(Thumbnail.Medium));
        ProcessImage(nameof(Thumbnail.Medium), mediumConfig);

        IConfiguration largeConfig = configuration
            .GetSection(nameof(Thumbnail.Large));
        ProcessImage(nameof(Thumbnail.Large), largeConfig);

        Console.WriteLine($"Watermark Text : {configuration["watermarkText"]}");
        Console.WriteLine($"Compression Level : {configuration["compressionLevel"]}");
    }

    private static void ProcessImage(string imageSize, IConfiguration config)
    {

        Console.WriteLine($"{imageSize} Width  : {config["width"]}");
        Console.WriteLine($"{imageSize} FilePrefix  : {config["filePrefix"]}");
    }
}

public class Thumbnail
{
    public string Width { get; set; }
    public string FilePrefix { get; set; }
    public string Medium { get; set; }
    public string Large { get; set; }
}
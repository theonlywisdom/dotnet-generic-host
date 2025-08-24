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
            .AddCommandLine(args, switchMappings)
            .Build();

        Console.WriteLine("***** Process Image *****");
        Console.WriteLine($" Processing: {args[0]}");

        var imageConfig = new ImageConfig() { 
            CompressionLevel = 0.99m
        };
        configuration.GetSection(nameof(ImageConfig)).Bind(imageConfig);

        ProcessImage(nameof(ImageConfig.Thumbnail), imageConfig.Thumbnail, imageConfig.CompressionLevel);
        ProcessImage(nameof(ImageConfig.Medium), imageConfig.Medium, imageConfig.CompressionLevel);
        ProcessImage(nameof(ImageConfig.Large), imageConfig.Large, imageConfig.CompressionLevel);

        Console.WriteLine($"Watermark Text : {configuration["watermarkText"]}");
        Console.WriteLine($"Compression Level : {configuration["compressionLevel"]}");
    }

    private static void ProcessImage(string imageSize, ImageSizeConfig config, decimal compressionLevel)
    {

        Console.WriteLine($"{imageSize} Width  : {config.Width}");
        Console.WriteLine($"{imageSize} FilePrefix : {config.FilePrefix}");
        Console.WriteLine($"{imageSize} Watermark  : {config.WaterMarkText}");
        Console.WriteLine($"{imageSize} Compression Level : {compressionLevel}");
    }
}
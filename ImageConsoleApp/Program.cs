using System;

namespace ImageConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .AddCommandLine(args)
            .Build();

        Console.WriteLine("***** Process Image *****");
        Console.WriteLine($" Processing: {args[0]}");

        Console.WriteLine($"Thumbnail Width: {configuration["thumbnailWidth"]}");
        Console.WriteLine($"Thumbnail FilePrefix: {configuration["thumbnailFilePrefix"]}");
        Console.WriteLine($"Medium Width : {configuration["mediumWidth"]}");
        Console.WriteLine($"Medium FilePrefix : {configuration["mediumWidthPrefix"]}");
        Console.WriteLine($"Large Width  : {configuration["largeWidth"]}");
        Console.WriteLine($"Large FilePrefix  : {configuration["largeWidthPrefix"]}");
        Console.WriteLine($"Watermark Text : {configuration["watermarkText"]}");
        Console.WriteLine($"Compression Level : {configuration["compressionLevel"]}");
    }
}

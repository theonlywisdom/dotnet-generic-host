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

        Console.WriteLine($"Thumbnail Width: {configuration["thumbnail:Width"]}");
        Console.WriteLine($"Thumbnail FilePrefix: {configuration["thumbnail:FilePrefix"]}");
        Console.WriteLine($"Medium Width : {configuration["medium:Width"]}");
        Console.WriteLine($"Medium FilePrefix : {configuration["medium:FilePrefix"]}");
        Console.WriteLine($"Large Width  : {configuration["large:Width"]}");
        Console.WriteLine($"Large FilePrefix  : {configuration["large:FilePrefix"]}");
        Console.WriteLine($"Watermark Text : {configuration["watermarkText"]}");
        Console.WriteLine($"Compression Level : {configuration["compressionLevel"]}");
    }
}

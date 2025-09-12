namespace ImageService;

public class ImageFileWatcher : IHostedService, IDisposable
{
    private readonly ILogger<ImageFileWatcher> _logger;
    private readonly IConfiguration _configuration;
    private FileSystemWatcher _watcher = new();

    public ImageFileWatcher(ILogger<ImageFileWatcher> logger, IConfiguration configuration, IOptions<ImageConfig> imageConfigOptions)
    {
        _logger = logger;
        _configuration = configuration;

        var imageConfig = imageConfigOptions.Value;
        logger.LogInformation("CompressionLevel: {CompressionLevel}", imageConfig.CompressionLevel);
        logger.LogInformation("OutputPath: {OutputPath}", imageConfig.OutputPath);
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("ImageFileWatcher watching: {watchPath} running at: {time}", _configuration["watchPath"], DateTimeOffset.Now);
        _watcher = new FileSystemWatcher
        {
            Path = _configuration["watchPath"],
            //Filter = "*.jpg",
            //NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
        };
        _watcher.Created += OnNewImage;
        _watcher.EnableRaisingEvents = true;

        return Task.CompletedTask;
    }

    private void OnNewImage(object sender, FileSystemEventArgs e)
    {
        _logger.LogInformation("New image: {FullPath}", e.FullPath);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("WorkImageFileWatcherer stopping at: {time}", DateTimeOffset.Now);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _logger.LogInformation("Disposing");
        _watcher.Dispose();
        GC.SuppressFinalize(this);
    }
}
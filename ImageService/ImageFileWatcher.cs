
namespace ImageService;

public class ImageFileWatcher(ILogger<ImageFileWatcher> logger, IConfiguration configuration) : IHostedService
{
    private readonly ILogger<ImageFileWatcher> _logger = logger;
    private readonly IConfiguration _configuration = configuration;
    private FileSystemWatcher _watcher;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("ImageFileWatcher running at: {time}", DateTimeOffset.Now);
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
}
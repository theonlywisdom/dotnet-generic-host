
namespace ImageService;

public class ImageFileWatcher(ILogger<ImageFileWatcher> logger) : IHostedService
{
    private readonly ILogger<ImageFileWatcher> _logger = logger;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("ImageFileWatcher running at: {time}", DateTimeOffset.Now);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("WorkImageFileWatcherer stopping at: {time}", DateTimeOffset.Now);
        return Task.CompletedTask;
    }
}
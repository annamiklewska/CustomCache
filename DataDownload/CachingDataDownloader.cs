using CustomCache.Classes;

namespace CustomCache.DataDownload;

public class CachingDataDownloader : IDataDownloader
{
    private IDataDownloader _dataDownloader = new SlowDataDownloader();
    private Cache<string, string> _cache = new ();
    public CachingDataDownloader(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }

    public string DownloadData(string resourceID)
    {
        return _cache.Get(resourceID, _dataDownloader.DownloadData);
    }
}
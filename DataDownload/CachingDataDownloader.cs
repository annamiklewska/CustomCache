using CustomCache.Classes;

namespace CustomCache.DataDownload;

public class CachingDataDownloader : IDataDownloader
{
    // DECORATOR design patter - this class implements the same interface as the decorated type (SlowDataDownloader)
    //and owns an instance of the decorated type
    //it follow the open-closed principle
    //class is open to extension
    //but closed to modification
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
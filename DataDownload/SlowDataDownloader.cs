namespace CustomCache.DataDownload;

public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceID)
    {
        // symulate a slow data download
        Thread.Sleep(2000);
        return $"Mock data for {resourceID}";
    }
}
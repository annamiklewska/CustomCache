using CustomCache.Classes;

namespace CustomCache.DataDownload;

public class PrintingDataDownloader : IDataDownloader
{
    // DECORATOR design patter - this class implements the same interface as the decorated type (SlowDataDownloader)
    //and owns an instance of the decorated type
    //it follow the open-closed principle
    //class is open to extension
    //but closed to modification
    private readonly IDataDownloader _dataDownloader;
    public PrintingDataDownloader(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }
    public string DownloadData(string resourceID)
    {
        var data = _dataDownloader.DownloadData(resourceID);
        Console.WriteLine("Data is read!");
        return data;
    }
}
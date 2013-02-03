using System;
using System.Net;

class DownloadFile
{
    static void DownloadFileFromWeb(string resourceUri, string pathToLocalFolder)
    {
        using (WebClient downloadClient = new WebClient())
        {
            try
            {
                downloadClient.DownloadFile(resourceUri, pathToLocalFolder);
            }
            catch (ArgumentNullException)
            {
                Console.Error.WriteLine("Either path to resource or path to local folder is empty.");
            }
            catch (WebException)
            {
                Console.Error.WriteLine("The URI provided is invalid -OR- File does not exist -OR- An error occured while downloading data.");
            }
            catch (NotSupportedException)
            {
                Console.Error.WriteLine("The method has been called simultaneously on multiple threads.");
            }
        }
    }
    static void Main()
    {
        //../.. -> exits two levels up in file directory tree in order to download file in main project folder
        DownloadFileFromWeb("http://www.devbg.org/img/Logo-BASD.jpg", "../../logo.jpg");
    }
}

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DownloadTester
//{
//    public class DownloadHttp: IDownload
//    {
//    }
//    DownloadWeb : IDownload

//    var httpclient = new HttpClient();
//    var response = await httpclient.GetAsync("http://weblog.west-wind.com/posts/2012/Aug/21/An-Introduction-to-ASPNET-Web-API",
//                                                HttpCompletionOption.ResponseHeadersRead);

//    string text = null;

//    using (var stream = await response.Content.ReadAsStreamAsync())
//    {
//        var bytes = new byte[1000];
//    var bytesread = stream.Read(bytes, 0, 1000);
//    stream.Close();

//        text = Encoding.UTF8.GetString(bytes);
//    }
//}

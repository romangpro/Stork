//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DownloadTester
//{
//    class DownloadReq
//    {
//        var request =
//        HttpWebRequest.Create("http://weblog.west-wind.com/posts/2012/Aug/21/An-Introduction-to-ASPNET-Web-API")
//            as HttpWebRequest;

//        request.AllowReadStreamBuffering = false;
//    request.AllowWriteStreamBuffering = false;

//    Stream stream;
//        byte[] buffer;
//    using (var response = await request.GetResponseAsync() as HttpWebResponse)
//    {
//        stream = response.GetResponseStream();
            
//        buffer = new byte[1000];
//        int byteCount = await stream.ReadAsync(buffer, 0, buffer.Length);
//    request.Abort();  // call ASAP to kill connection          
//        response.Close();
//    }
//stream.Close();

//    string text = Encoding.UTF8.GetString(buffer);
//    }
//}

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DownloadTester
{
    public class DownloadWeb : IDownload
    {
        public Uri Uri { get; set; }
        public byte[] Bytes { get; set; }

        private ILogger _log;
        private WebClient _client;

        public DownloadWeb(string uri, ILogger log)
        {
            Uri = new Uri(uri);
            _log = log;
            _client = new WebClient();
            
            _client.DownloadProgressChanged += Client_DownloadProgressChanged;
            _client.DownloadDataCompleted += Client_DownloadDataCompleted;
            Console.WriteLine("cache policy: " + _client.CachePolicy?.Level);
        }

        public async Task<byte[]> Start()
        {
            return await _client.DownloadDataTaskAsync(Uri);
        }

        public async Task<byte[]> StartChunkReverseBytes(int size)
        {
            _client.Headers.Add(HttpRequestHeader.ContentRange, "bytes 1000-1000000");
            return await _client.DownloadDataTaskAsync(Uri);
        }


        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            _log.Progress(Uri, e);
        }

        private void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            _log.Complete(Uri, e);
        }
    }
}

//        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
//        long bytesReceived = 0;
//        foreach (NetworkInterface inf in interfaces)
//        {
//            if (inf.OperationalStatus == OperationalStatus.Up &&
//                inf.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
//                inf.NetworkInterfaceType != NetworkInterfaceType.Tunnel &&
//                inf.NetworkInterfaceType != NetworkInterfaceType.Unknown && !inf.IsReceiveOnly)
//            {
//                bytesReceived += inf.GetIPv4Statistics().BytesReceived;
//            }
//}

//        if (bytesReceivedPrev == 0)
//        {
//            bytesReceivedPrev = bytesReceived;
//        }
//        long bytesUsed = bytesReceived - bytesReceivedPrev;
//double kBytesUsed = bytesUsed / 1024;
//double mBytesUsed = kBytesUsed / 1024;
//internetUsage.Add(now, mBytesUsed);
//        if (internetUsage.Count > 20)
//        {
//            internetUsage.Remove(internetUsage.Keys.First());
//        }
//        bytesReceivedPrev = bytesReceived;
//    }
//}

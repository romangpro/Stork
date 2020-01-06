using System;
using System.Collections.Generic;
using System.Net;

namespace DownloadTester
{
    public interface ILogger
    {
        void Progress(Uri uri, DownloadProgressChangedEventArgs a);
        void Complete(Uri uri, DownloadDataCompletedEventArgs a);
    }

    public class Logger : ILogger
    {
        public Uri Uri;
        public long TotalBytes;
        public List<(int Percent, long Bytes)> list = new List<(int Percent, long Bytes)>();
        public DateTime LastUpdate = DateTime.UtcNow;

        public void Progress(Uri uri, DownloadProgressChangedEventArgs a)
        {
            if (Uri == null)
            {
                Console.WriteLine($"[D] {uri.LocalPath} {a.TotalBytesToReceive,20}");
                Uri = uri;
                TotalBytes = a.TotalBytesToReceive;
            }
            list.Add((a.ProgressPercentage, a.BytesReceived));
            var t = DateTime.UtcNow.Subtract(LastUpdate);
            if (t.TotalSeconds >= 1.0)
            {
                Console.WriteLine($"{DateTime.UtcNow.ToString("hh:mm:ss.ffff tt"),10} {a.ProgressPercentage,10} {a.BytesReceived,10}");
                LastUpdate = DateTime.UtcNow;
            }
        }

        public void Complete(Uri uri, DownloadDataCompletedEventArgs a)
        {
            Console.WriteLine($"[D] {uri.LocalPath:20} {a.Result}");
        }
    }
}

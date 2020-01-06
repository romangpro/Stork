using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DownloadTester
{
    public interface IDownload
    {
        Uri Uri { get; set; }
        byte[] Bytes { get; set; }

        Task<byte[]> Start();
        Task<byte[]> StartChunkReverseBytes(int size);
    }
}

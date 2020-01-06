using System;
using System.Threading.Tasks;

namespace DownloadTester
{
    class Program
    {
        static async Task Main(string[] args)
        {

            //http://asset.synergysportstech.com/wmsd/2/485814/gameon/201986300.mp4
            string s1 = "http://akabellstorage05wan.synergysportstech.com/AwareNetWMS2/2/485814/gameon/201986300.mp4";
            //http://asset.synergysportstech.com/wms/2/296560/152301561.mp4
            //string s2 = "http://akabellstorage05wan.synergysportstech.com/AwareNetWMS2/2/296560/152301561.mp4";
            Console.WriteLine("Hello World!");
            var logger = new Logger();
            var d1 = new DownloadWeb(s1, logger);
            var b = await d1.StartChunkReverseBytes(1);

            Console.WriteLine("FINISH");
            Console.ReadLine();
        }
    }
}

using System;
using System.Reflection;
using Serilog;
using Serilog.Core;

namespace AllegroAuctioneer
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = CreateLogger();
            var allegro = new AllegroHttpClient(new Uri("https://allegro.pl"), logger);
            allegro.SignIn("dupa", "dupa");
            Console.ReadKey();
        }

        private static Logger CreateLogger()
        {
            var localPath = Assembly.GetExecutingAssembly().Location;
            return new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(path: localPath, fileSizeLimitBytes: null, retainedFileCountLimit: 3)
                .CreateLogger();
        }
    }
}

using System;

namespace AllegroAuctioneer
{
    class Program
    {
        static void Main(string[] args)
        {
            var allegro = new AllegroHttpClient(new Uri("https://allegro.pl"));
            Console.WriteLine(allegro.SignIn("dupa", "dupa"));
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;

namespace AllegroAuctioneer
{
    class AllegroHttpClient : HttpClient
    {
        private readonly HttpClient client;
        private readonly string loginUrl;
        public AllegroHttpClient(Uri allegroUri)
        {
            client = new HttpClient();
            client.BaseAddress = allegroUri;
            loginUrl = "login/auth";
        }

        public string SignIn(string login, string password)
        {
            
            var loginPage = client.GetAsync(loginUrl).Result;
            var sb = new StringBuilder();

            foreach(var header in loginPage.Headers)
            {
                foreach (var val in header.Value)
                {
                    sb.AppendLine(string.Join(" :\t", new string[] { header.Key, val }));
                }
            }
            return sb.ToString();
        }
    }
}

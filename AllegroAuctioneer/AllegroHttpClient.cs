using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace AllegroAuctioneer
{
    class AllegroHttpClient : HttpClient
    {
        private readonly HttpClient _client;
        private readonly Uri _uri;
        private readonly string loginUrl;
        private readonly ILogger _logger;
        private readonly HttpClientHandler _httpClientHandler;
        public AllegroHttpClient(Uri allegroUri, ILogger logger)
        {
            _uri = allegroUri;
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.CookieContainer = new CookieContainer();

            _client = new HttpClient(_httpClientHandler);
            _client.BaseAddress = _uri;
            loginUrl = "login/auth";
            _logger = logger;
        }

        public void SignIn(string login, string password)
        {
            HttpResponseMessage loginResponse;
            try
            {
                loginResponse = _client.GetAsync(loginUrl).Result;
                loginResponse.EnsureSuccessStatusCode();

                CookieCollection cookies = _httpClientHandler.CookieContainer.GetCookies(_uri);
                foreach (var cookie in cookies)
                {
                    _logger.Information(cookie.ToString());
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.Error(ex, "Error when connecting to allegro");
            }
        }
    }
}

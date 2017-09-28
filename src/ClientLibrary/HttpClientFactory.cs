using System;
using System.Net.Http;

namespace ClientLibrary
{
    internal static class HttpClientFactory
    {
        private static HttpClient _httpClient = new HttpClient() { BaseAddress = new Uri("http://fake.checkout.com") };

        internal static HttpClient Get()
        {
            return _httpClient;
        }

        internal static void SetBaseAddress(string baseAddress) => _httpClient.BaseAddress = new Uri(baseAddress); 
    }
}

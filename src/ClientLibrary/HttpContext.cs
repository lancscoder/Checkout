namespace ClientLibrary
{
    public static class HttpContext
    {
        public static void SetProxyBaseAddress(string baseAddress)
        {
            HttpClientFactory.SetBaseAddress(baseAddress);
        }
    }
}

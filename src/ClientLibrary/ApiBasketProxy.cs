using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary
{
    internal class ApiBasketProxy : IApiBasketProxy
    {
        public async Task<Basket> GetBasket(Guid id)
        {
            var httpClient = HttpClientFactory.Get();

            var response = await httpClient.GetAsync($"/api/basket/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Cannot find basket.");
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Retrieving basket failed");
            }

            var json = await response.Content.ReadAsStringAsync();

            var basket = JsonConvert.DeserializeObject<Basket>(json);

            return basket;
        }

        public async Task<Basket> CreateBasket()
        {
            var httpClient = HttpClientFactory.Get();

            var response = await httpClient.PostAsync("/api/basket/", new StringContent("", Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Create basket failed");
            }

            var json = await response.Content.ReadAsStringAsync();

            var basket = JsonConvert.DeserializeObject<Basket>(json);

            return basket;
        }
    }
}

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary
{
    internal class ApiItemProxy : IApiItemProxy
    {
        public async Task AddItem(Guid basketId, string description, int quantity = 1)
        {
            var httpClient = HttpClientFactory.Get();

            var postItem = new StringContent("{ description: \"" + description + "\", quantity: \""+ quantity +"\" }", Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"/api/basket/{basketId}/items", postItem);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Create item failed");
            }
        }

        public async Task UpdateItem(Guid basketId, Guid id, int quantity)
        {
            var httpClient = HttpClientFactory.Get();

            var putItem = new StringContent("{ quantity: \"" + quantity + "\" }", Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"/api/basket/{basketId}/items/{id}", putItem);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Update item failed");
            }
        }

        public async Task ClearItems(Guid basketId)
        {
            var httpClient = HttpClientFactory.Get();
            
            var response = await httpClient.DeleteAsync($"/api/basket/{basketId}/items/");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Clear items failed");
            }
        }
    }
}

using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Blazor.Data.Models;
using Blazor.Services;

namespace Blazor.Services
{
    public class ItemsProvider : IItemProvider
    {
        private HttpClient _client;
        public ItemsProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Item>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<Item>>("/api/item");
        }

        public async Task<Item> GetOne(int id)
        {
            return await _client.GetFromJsonAsync<Item>($"/api/item/{id}");
        }

        public async Task<bool> Add(Item item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync($"/api/item", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Item> Edit(Item item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PutAsync($"/api/item", httpContent);
            Item item1 = JsonConvert.DeserializeObject<Item>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(item1);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _client.DeleteAsync($"/api/item/${id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }

    }
}


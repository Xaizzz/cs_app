
using BlazorApp1.Data.Models;

namespace BlazorApp1.Data.Services;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using BlazorApp1.Data;



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

        public async Task<bool> Add(Item item1)
        {
            string data = JsonConvert.SerializeObject(item1);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync($"/api/item", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Item> Edit(Item item1)
        {
            string data = JsonConvert.SerializeObject(item1);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PutAsync($"/api/item", httpContent);
            Item item = JsonConvert.DeserializeObject<Item>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(item);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _client.DeleteAsync($"/api/item/${id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }


    }

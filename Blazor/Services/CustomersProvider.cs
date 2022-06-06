using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Blazor.Data.Models;
using Blazor.Services;

namespace Blazor.Services
{
    public class CustomerProvider :ICustomerProvider
    {
        private HttpClient _client;
        public CustomerProvider(HttpClient customer)
        {
            _client = customer;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<Customer>>("/api/customer");
        }

        public async Task<Customer> GetOne(int id)
        {
            return await _client.GetFromJsonAsync<Customer>($"/api/customer/{id}");
        }

        public async Task<bool> Add(Customer item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync($"/api/customer", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Customer> Edit(Customer item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PutAsync($"/api/customer", httpContent);
            Customer customer = JsonConvert.DeserializeObject<Customer>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(customer);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _client.DeleteAsync($"/api/customer/${id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }

    }
}


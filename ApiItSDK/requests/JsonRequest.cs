using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace lib.requests
{
    public class JsonRequest : IRequest
    {
        private readonly HttpClient _client;

        public JsonRequest(HttpClient client)
        {
            this._client = client;
        }

        public async Task<T> GetData<T>(string url)
        {
            var response = await this._client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content);
            }
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
        }

        public async Task PostData<T>(T data, string url)
        {
            var jsonContent = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await this._client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task PutData<T>(T data, string url)
        {
            var jsonContent = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await this._client.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteData(string url)
        {
            var response = await this._client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }

        public async Task PatchData<T>(T data, string url)
        {
            var jsonContent = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await this._client.PatchAsync(url, content);
            response.EnsureSuccessStatusCode();
        }
    }
}

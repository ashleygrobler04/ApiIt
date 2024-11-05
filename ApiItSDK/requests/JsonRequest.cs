using System.Net;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lib.requests
{
    public class JsonRequest : IRequest
    {
        private readonly HttpClient _client;

        public JsonRequest(HttpClient client)
        {
            this._client = client;
        }

        public async Task<Result<JObject>> GetData(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JObject.Parse(content);
                    return Result<JObject>.Succeed(data);
                }
                return Result<JObject>.Fail($"GET request failed with status {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception e)
            {
                return Result<JObject>.Fail(e.Message);
            }
        }

        public async Task<Result<T>> PostData<T>(T data, string url)
        {
            try
            {
                var response = await _client.PostAsJsonAsync(url, data);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var resultData = JsonConvert.DeserializeObject<T>(responseData);
                    return Result<T>.Succeed(resultData);
                }
                return Result<T>.Fail($"POST request failed with status {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(ex.Message);
            }
        }

        public async Task<Result<T>> PutData<T>(T data, string url)
        {
            try
            {
                var response = await _client.PutAsJsonAsync(url, data);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var resultData = JsonConvert.DeserializeObject<T>(responseData);
                    return Result<T>.Succeed(resultData);
                }
                return Result<T>.Fail($"PUT request failed with status {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(ex.Message);
            }
        }

        public async Task<Result<T>> DeleteData<T>(string url)
        {
            try
            {
                var response = await _client.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var content=JsonConvert.DeserializeObject<T>(responseData);
                    return Result<T>.Succeed(content);
                }
                return Result<T>.Fail($"DELETE request failed with status {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(ex.Message);
            }
        }

        public async Task<Result<T>> PatchData<T>(T data, string url)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Patch, url) { Content = content };
                var response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var resultData = JsonConvert.DeserializeObject<T>(responseData);
                    return Result<T>.Succeed(resultData);
                }
                return Result<T>.Fail($"PATCH request failed with status {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(ex.Message);
            }
        }

    }
}

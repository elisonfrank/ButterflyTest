using Newtonsoft.Json;
using System.Text;

namespace Calculator.Helpers
{
    public class HttpClientBase
    {
        private readonly HttpClient _client;

        public Dictionary<string, string> Headers { get; set; }

        public HttpClientBase()
        {
            _client = new();
        }

        public async Task<T> GetAsync<T>(string url) where T : struct
        {
            InsertHeaders();
            _client.BaseAddress = new Uri(url);
            
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(stringData);
                return data;
            }

            return default(T);
        }

        public async Task<T> PostAsync<T>(string url, T data) where T : struct
        {
            InsertHeaders();
            _client.BaseAddress = new Uri(url);

            var json = JsonConvert.SerializeObject(data);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var stringData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(stringData);
                return result;
            }

            return default(T);
        }

        public async Task<T> PostAsync<T>(string url, Dictionary<string, string> parameters) where T : struct
        {
            InsertHeaders();
            _client.BaseAddress = new Uri(url);
            
            var encodedContent = new FormUrlEncodedContent(parameters);

            var response = await _client.PostAsync(url, encodedContent);
            if (response.IsSuccessStatusCode)
            {
                var stringData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(stringData);
                return data;
            }

            return default(T);
        }

        private void InsertHeaders()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            foreach (var header in Headers)
                _client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
    }
}

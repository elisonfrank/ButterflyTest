namespace Calculator.Helpers
{
    public class CalculatorClient : HttpClientBase
    {
        private readonly string _baseUrl = "http://localhost:5094/api/Calculator";
        private readonly string _addUrl = "/add";
        private readonly string _subtractdUrl = "/subtract";
        private readonly string _multiplydUrl = "/multiply";
        private readonly string _dividedUrl = "/divide";

        public CalculatorClient()
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Accept", "application/json");
            base.Headers = headers;
        }

        public async Task<T> Add<T>(Dictionary<string, string> parameters) where T : struct
        {
            return await PostAsync<T>(_baseUrl + _addUrl, parameters);
        }

        public async Task<T> Subtract<T>(Dictionary<string, string> parameters) where T : struct
        {
            return await PostAsync<T>(_baseUrl + _subtractdUrl, parameters);
        }

        public async Task<T> Multiply<T>(Dictionary<string, string> parameters) where T : struct
        {
            return await PostAsync<T>(_baseUrl + _multiplydUrl, parameters);
        }

        public async Task<T> Divide<T>(Dictionary<string, string> parameters) where T : struct
        {
            return await PostAsync<T>(_baseUrl + _dividedUrl, parameters);
        }
    }
}

using Polly.Wrap;

namespace PollyAutofacDemo.Services
{
    public class YourService : IYourService
    {
        private readonly HttpClient _httpClient;
        private readonly AsyncPolicyWrap<HttpResponseMessage> _resiliencePolicy;

        public YourService(HttpClient httpClient, AsyncPolicyWrap<HttpResponseMessage> resiliencePolicy)
        {
            _httpClient = httpClient;
            _resiliencePolicy = resiliencePolicy;
        }

        public async Task<string> GetDataAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.example.com/data");

            var response = await _resiliencePolicy.ExecuteAsync(() => _httpClient.SendAsync(request));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                throw new Exception("Failed to get data.");
            }
        }
    }
}

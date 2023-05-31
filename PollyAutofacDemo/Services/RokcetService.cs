using Polly;

namespace PollyAutofacDemo.Services
{
    public class RokcetService : IRokcetService
    {
        private readonly HttpClient _httpClient;

        public RokcetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetRokcetDataAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.example.com/data");
            return null;
            //var retryPolicy = Policy.Handle<HttpRequestException>()
            //    .WaitAndRetryAsync(RetryCount, i => RetryInterval);

            //var fallbackPolicy = Policy.Handle<Exception>()
            //    .FallbackAsync("Fallback data");

            //var circuitBreakerPolicy = Policy.Handle<Exception>()
            //    .CircuitBreakerAsync(RetryCount, BreakDuration);

            //var policyWrap = Policy.WrapAsync(retryPolicy, fallbackPolicy, circuitBreakerPolicy);

            //var response = await policyWrap.ExecuteAsync(() => _httpClient.SendAsync(request));

            //if (response.IsSuccessStatusCode)
            //{
            //    var content = await response.Content.ReadAsStringAsync();
            //    return content;
            //}
            //else
            //{
            //    throw new Exception("Failed to get data.");
            //}
        }
    }

}

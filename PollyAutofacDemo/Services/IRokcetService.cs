using Polly.Retry;
using PollyAutofacDemo.Interceptors;

namespace PollyAutofacDemo.Services
{
    [PollyPolicy(typeof(RetryPolicy))]
    public interface IRokcetService
    {
        [PollyPolicyConfig(3, 2, 30)]
        Task<string> GetRokcetDataAsync();
    }
}

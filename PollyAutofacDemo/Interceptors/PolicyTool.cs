using Polly.Wrap;
using Polly;
using System.Net;

namespace PollyAutofacDemo.Interceptors
{
    public class PolicyTool
    {
        //public static AsyncPolicyWrap<HttpResponseMessage> CreateResiliencePolicy()
        //{
        //    var retryPolicy = Policy.Handle<HttpRequestException>()
        //        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        //    var fallbackPolicy = Policy.Handle<Exception>()
        //        .FallbackAsync(FallbackResponse, onFallbackAsync: async ex =>
        //        {
        //            // 记录降级日志
        //        });

        //    var circuitBreakerPolicy = Policy.Handle<Exception>()
        //        .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30),
        //            onBreak: (ex, span) =>
        //            {
        //                // 记录熔断日志
        //            },
        //            onReset: () =>
        //            {
        //                // 记录熔断重置日志
        //            });

        //    var resiliencePolicy = Policy.WrapAsync(retryPolicy, fallbackPolicy, circuitBreakerPolicy);

        //    return resiliencePolicy;
        //}
        //public static AsyncPolicyWrap<HttpResponseMessage> CreateResiliencePolicy()
        //{
        //    var retryPolicy = Policy.Handle<HttpRequestException>()
        //        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        //    var fallbackPolicy = Policy.Handle<Exception>()
        //        .FallbackAsync(FallbackResponse, onFallbackAsync: async ex =>
        //        {
        //            // 记录降级日志
        //        });

        //    var circuitBreakerPolicy = Policy.Handle<Exception>()
        //        .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30),
        //            onBreak: (ex, span) =>
        //            {
        //                // 记录熔断日志
        //            },
        //            onReset: () =>
        //            {
        //                // 记录熔断重置日志
        //            });

        //    var resiliencePolicy = Policy.WrapAsync<HttpResponseMessage>(retryPolicy, fallbackPolicy, circuitBreakerPolicy);

        //    return resiliencePolicy;
        //}

        //public static AsyncPolicyWrap<HttpResponseMessage> CreateResiliencePolicy()
        //{
        //    var retryPolicy = Policy.Handle<HttpRequestException>()
        //        .RetryAsync(3, onRetry: (ex, retryCount) =>
        //        {
        //            // 记录重试日志
        //        });

        //    var fallbackPolicy = Policy.Handle<Exception>()
        //        .FallbackAsync(FallbackResponse, onFallbackAsync: async ex =>
        //        {
        //            // 记录降级日志
        //        });

        //    var circuitBreakerPolicy = Policy.Handle<Exception>()
        //        .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30),
        //            onBreak: (ex, span) =>
        //            {
        //                // 记录熔断日志
        //            },
        //            onReset: () =>
        //            {
        //                // 记录熔断重置日志
        //            });

        //    var resiliencePolicy = Policy.WrapAsync<HttpResponseMessage>(retryPolicy, fallbackPolicy, circuitBreakerPolicy);

        //    return resiliencePolicy;
        //}
        //private static Task<HttpResponseMessage> FallbackResponse(CancellationToken cancellationToken)
        //{
        //    // 创建一个默认的降级响应
        //    var fallbackResponse = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new StringContent("降级响应")
        //    };

        //    return Task.FromResult(fallbackResponse);
        //}

        //private static Task<HttpResponseMessage> FallbackResponse(Context context, CancellationToken cancellationToken)
        //{
        //    var fallbackContent = new StringContent("Fallback response");
        //    var fallbackResponse = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = fallbackContent
        //    };
        //    return Task.FromResult(fallbackResponse);
        //}
    }
}

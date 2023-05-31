using Castle.DynamicProxy;
using Polly.Retry;
using Polly;
using System.Reflection;

namespace PollyAutofacDemo.Interceptors
{
    public class RocketInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;

            var policyAttribute = method.DeclaringType.GetCustomAttribute<PollyPolicyAttribute>();
            var configAttribute = method.GetCustomAttribute<PollyPolicyConfigAttribute>();

            if (policyAttribute != null && configAttribute != null)
            {
                var policyType = policyAttribute.PolicyType;
                var retryCount = configAttribute.RetryCount;
                var retryInterval = configAttribute.RetryInterval;

                // 创建和配置策略
                var policy = CreatePolicy(policyType, retryCount, retryInterval);

                // 应用策略
                invocation.Proceed();
            }
            else
            {
                invocation.Proceed();
            }
        }

        private AsyncPolicy CreatePolicy(Type policyType, int retryCount, TimeSpan retryInterval)
        {
            if (policyType == typeof(RetryPolicy))
            {
                return Policy.Handle<Exception>().WaitAndRetryAsync(retryCount, _ => retryInterval);
            }
            else
            {
                throw new ArgumentException("Unsupported policy type");
            }
        }
    }
}

namespace PollyAutofacDemo.Interceptors
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class PollyPolicyConfigAttribute : Attribute
    {
        public int RetryCount { get; set; }
        public TimeSpan RetryInterval { get; set; }
        public TimeSpan BreakDuration { get; set; }
        public Type FallbackHandlerType { get; set; }

        public PollyPolicyConfigAttribute(int retryCount, double retryIntervalSeconds, double breakDurationSeconds)
        {
            RetryCount = retryCount;
            RetryInterval = TimeSpan.FromSeconds(retryIntervalSeconds);
            BreakDuration = TimeSpan.FromSeconds(breakDurationSeconds);
        }
    }

}

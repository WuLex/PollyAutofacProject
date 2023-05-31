namespace PollyAutofacDemo.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface, AllowMultiple = false)]
    public class PollyPolicyAttribute : Attribute
    {
        public Type PolicyType { get; }

        public PollyPolicyAttribute(Type policyType)
        {
            PolicyType = policyType;
        }
    }
}

using Castle.DynamicProxy;

namespace PollyAutofacDemo.Interceptors
{
    public class YourInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                // 执行方法前的逻辑

                invocation.Proceed();

                // 执行方法后的逻辑
            }
            catch (Exception ex)
            {
                // 处理异常
            }
        }
    }
}

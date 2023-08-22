using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AutofacProject.Interceptors
{
    public class LoggingInterceptor : Castle.DynamicProxy.IInterceptor
    {
        private readonly ILogger<LoggingInterceptor> _logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            _logger.Log(LogLevel.Information, $"在调用{invocation.Method.Name} 方法之前");

            try
            {
                invocation.Proceed();
                _logger.Log(LogLevel.Information, $"在调用 {invocation.Method.Name} 方法之后");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{invocation.Method.Name}方法中出现错误");
                throw;
            }
        }
    }
}

using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using AutofacProject.Commom;
using AutofacProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.Tracing;

var builder = WebApplication.CreateBuilder(args);

//默认 ASP.NET Core Web 应用模板：
//使用通用主机。
//调用 WebApplication.CreateBuilder，这将添加以下日志记录提供程序：
//控制台
//调试
//EventSource
//EventLog：仅限 Windows
builder.Logging.ClearProviders();
builder.Logging.AddConsole();



// 使用 Autofac 替换默认的 DI 容器
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//在.NET 6中配置Autofac容器的方法
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // 注册依赖注入服务
    containerBuilder.RegisterModule(new AutofacModule());
    // 注册AOP模块
    containerBuilder.RegisterModule(new AopModule());
});

// 获取配置文件
var configuration = builder.Configuration;
// 添加数据库上下文服务
builder.Services.AddDbContext<MusicContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("MusicDbConnection")));

 
// 添加控制器和视图服务
builder.Services.AddControllersWithViews();


var app = builder.Build();

//启用 HTTP 日志记录
//app.UseHttpLogging();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

#region 获取应用程序的生命周期对象，并注册一个回调函数，在应用程序停止时执行该回调函数
var applicationLifetime = app.Services.GetService<IHostApplicationLifetime>();
applicationLifetime.ApplicationStopped.Register(() => { }); 
#endregion


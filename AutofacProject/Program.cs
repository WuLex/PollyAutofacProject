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

//Ĭ�� ASP.NET Core Web Ӧ��ģ�壺
//ʹ��ͨ��������
//���� WebApplication.CreateBuilder���⽫���������־��¼�ṩ����
//����̨
//����
//EventSource
//EventLog������ Windows
builder.Logging.ClearProviders();
builder.Logging.AddConsole();



// ʹ�� Autofac �滻Ĭ�ϵ� DI ����
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//��.NET 6������Autofac�����ķ���
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // ע������ע�����
    containerBuilder.RegisterModule(new AutofacModule());
    // ע��AOPģ��
    containerBuilder.RegisterModule(new AopModule());
});

// ��ȡ�����ļ�
var configuration = builder.Configuration;
// ������ݿ������ķ���
builder.Services.AddDbContext<MusicContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("MusicDbConnection")));

 
// ��ӿ���������ͼ����
builder.Services.AddControllersWithViews();


var app = builder.Build();

//���� HTTP ��־��¼
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

#region ��ȡӦ�ó�����������ڶ��󣬲�ע��һ���ص���������Ӧ�ó���ֹͣʱִ�иûص�����
var applicationLifetime = app.Services.GetService<IHostApplicationLifetime>();
applicationLifetime.ApplicationStopped.Register(() => { }); 
#endregion


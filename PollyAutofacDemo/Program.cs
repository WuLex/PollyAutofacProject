using Autofac.Core;
using Autofac;
using PollyAutofacDemo.Interceptors;
using PollyAutofacDemo.Services;
using Autofac.Extras.DynamicProxy;
using Polly.Wrap;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// ×¢²áAutofac²¢ÆôÓÃAOP
var containbuilder = new ContainerBuilder();
containbuilder.RegisterType<YourService>().As<IYourService>().EnableInterfaceInterceptors();
containbuilder.RegisterType<YourInterceptor>();
containbuilder.Build();

// ×¢²áPolly²ßÂÔ
//builder.Services.AddSingleton(PolicyTool.CreateResiliencePolicy());


var app = builder.Build();

// Configure the HTTP request pipeline.
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



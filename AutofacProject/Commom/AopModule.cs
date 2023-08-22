using Autofac;
using Autofac.Extras.DynamicProxy;
using AutofacProject.Controllers;
using AutofacProject.Interceptors;
using AutofacProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace AutofacProject.Commom
{
    public class AopModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
             
            // 注册LoggingInterceptor拦截器
            builder.RegisterType<LoggingInterceptor>();

            // 注册MusicRepository类，并启用AOP拦截
            builder.RegisterType<MusicRepository>()
                .As<IMusicRepository>()
                .EnableInterfaceInterceptors() // 启用接口拦截
                .InterceptedBy(typeof(LoggingInterceptor)); // 使用LoggingInterceptor拦截器

            // 注册ILogger实例
            //builder.Register(c => new LoggerFactory().CreateLogger<LoggingInterceptor>())
            //    .As<ILogger<LoggingInterceptor>>();

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PublicOnly();



            // 注册拦截器到需要拦截的服务类型中
            //builder.RegisterAssemblyTypes(typeof(MusicController).Assembly)
            //    .Where(t => t.Name.EndsWith("Controller"))
            //    .AsSelf()
            //    .EnableClassInterceptors() // 启用类的动态代理
            //    .InterceptedBy(typeof(LoggingInterceptor)); // 使用LoggingInterceptor拦截器

            //builder.RegisterType<MusicRepository>().As<IMusicRepository>().EnableClassInterceptors().InterceptedBy(typeof(LoggingInterceptor)); // 开启类拦截器 
            // builder.RegisterType<MusicRepository>().As<IMusicRepository>().EnableInterfaceInterceptors(); // 开启接口拦截器


            // 注册所有的Controllers
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //.Where(t => typeof(Controller).IsAssignableFrom(t))
            //.PropertiesAutowired();

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //        .Where(t => t.Name.EndsWith("Repository"))
            //        .AsImplementedInterfaces();

        }
    }
}

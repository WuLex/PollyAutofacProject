using Autofac;
using Autofac.Core;
using AutofacProject.Repositories;

namespace AutofacProject.Commom
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // 注册服务、组件等到容器中
            builder.RegisterType<MusicRepository>()
                .As<IMusicRepository>()
                .InstancePerLifetimeScope();

            // 注册服务
            //builder.RegisterType<MyService>().As<IMyService>();
            // 注册组件
            //builder.RegisterComponent<MyComponent>();
        }
    }
}

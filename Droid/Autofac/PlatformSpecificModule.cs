using Autofac;
using DataBaseApp.Services.Interfaces;

namespace DataBaseApp.Droid.Autofac
{
    internal class PlatformSpecificModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<SqLiteDbPath>().As<ISqLiteDbPath>().SingleInstance();
        }
    }
}
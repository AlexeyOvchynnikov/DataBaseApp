

using Autofac;
using DataBaseApp.Services;
using DataBaseApp.Services.Interfaces;

namespace DataBaseApp.Autofac
{
    internal class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<SqLiteConnection>().As<ISqLiteConnection>().SingleInstance();
            builder.RegisterType<DatabaseMigrationService>().As<IMigrationService>().SingleInstance();
            builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();
        }
    }
}

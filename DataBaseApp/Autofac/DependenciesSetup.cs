using Autofac;
using Autofac.Core;

namespace DataBaseApp.Autofac
{
    internal class DependenciesSetup
    {
        internal IContainer PrepareContainer(IModule platformSpecificModule, IModule applicationModule)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(platformSpecificModule);
            containerBuilder.RegisterModule(applicationModule);
            return containerBuilder.Build();
        }
    }
}

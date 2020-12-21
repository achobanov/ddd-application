using Prism.Ioc;
using System;

namespace EnduranceContestManager.Gateways.Desktop.Core.DI
{
    internal class DesktopContainerAdapter
    {
        private readonly IContainerRegistry container;

        public DesktopContainerAdapter(IContainerRegistry container)
        {
            this.container = container;
        }

        internal void RegisterSingleton(Type service, object implementation)
            => this.container.RegisterSingleton(service, () => implementation);

        internal void RegisterSingleton(Type service, Type implementation)
            => this.container.RegisterSingleton(service, implementation);

        internal void RegisterSingleton(
            Type service,
            Func<IServiceProvider, object> factory)
            => this.container.RegisterSingleton(service, this.ToDryIotFactory(factory));

        internal void Register(Type service, object implementation)
            => this.container.Register(service, () => implementation);

        internal void Register(Type service, Type implementation)
            => this.container.Register(service, implementation);

        internal void Register(
            Type service,
            Func<IServiceProvider, object> factory)
            => this.container.Register(service, this.ToDryIotFactory(factory));


        private Func<IContainerProvider, object> ToDryIotFactory(Func<IServiceProvider, object> factory)
            => container =>
            {
                var provider = container.Resolve<IServiceProvider>();
                return factory(provider);
            };
    }
}
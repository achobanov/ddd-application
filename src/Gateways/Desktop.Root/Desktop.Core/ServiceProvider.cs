using Prism.Ioc;
using System;

namespace EnduranceContestManager.Gateways.Desktop.Core
{
    public class ServiceProvider : IServiceProvider
    {
        private readonly IContainerProvider containerProvider;

        public ServiceProvider(IContainerProvider containerProvider)
        {
            this.containerProvider = containerProvider;
        }
        
        public object GetService(Type serviceType)
            => this.containerProvider.Resolve(serviceType);
    }
}
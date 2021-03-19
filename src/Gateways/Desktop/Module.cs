using EnduranceJudge.Application.Test;
using EnduranceJudge.Core.Interfaces;
using EnduranceJudge.Gateways.Desktop.Views;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Linq;

namespace EnduranceJudge.Gateways.Desktop
{
    public class Module : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IDateTimeService dateTime;

        public Module(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        public async void OnInitialized(IContainerProvider containerProvider)
        {
            var aspNetProvider = containerProvider.Resolve<IServiceProvider>();
            var initializers = aspNetProvider.GetServices<IInitializerInterface>();
            foreach (var initializer in initializers.OrderBy(x => x.RunningOrder))
            {
                await initializer.Run(aspNetProvider);
            }

            var mediator = containerProvider.Resolve<IMediator>();

            var test = new Test
            {
                Name = "TestName",
            };

            await mediator.Send(test);

            this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }
    }
}

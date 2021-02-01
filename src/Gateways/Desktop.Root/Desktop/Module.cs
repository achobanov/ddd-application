using EnduranceContestManager.Application.Contests.Commands;
using EnduranceContestManager.Application.Contests.Queries.Details;
using EnduranceContestManager.Application.Test;
using EnduranceContestManager.Core.Interfaces;
using EnduranceContestManager.Gateways.Desktop.Interfaces;
using EnduranceContestManager.Gateways.Desktop.Views;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;

namespace EnduranceContestManager.Gateways.Desktop
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
            foreach (var initializer in initializers)
            {
                await initializer.Run(aspNetProvider);
            }

            var mediator = containerProvider.Resolve<IMediator>();

            var test = new Test();

            await mediator.Send(test);

            this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }
    }
}

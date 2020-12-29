using EnduranceContestManager.Application.Articles.Queries.Details;
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
        private readonly IDateTime dateTime;

        public Module(IRegionManager regionManager, IDateTime dateTime)
        {
            this.regionManager = regionManager;
            this.dateTime = dateTime;
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

            var query = new GetArticleDetails { Id = 1 };
            var result = await mediator.Send(query);

            this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }
    }
}
using EnduranceJudge.Application.Test;
using EnduranceJudge.Core.Interfaces;
using EnduranceJudge.Gateways.Desktop.Views;
using EnduranceJudge.Gateways.Desktop.Views.Content;
using EnduranceJudge.Gateways.Desktop.Views.Navigation;
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

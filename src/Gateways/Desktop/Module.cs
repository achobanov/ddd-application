using EnduranceJudge.Application.Test;
using EnduranceJudge.Core.Interfaces;
using EnduranceJudge.Gateways.Desktop.ViewComponents;
using EnduranceJudge.Gateways.Desktop.ViewComponents.Content;
using EnduranceJudge.Gateways.Desktop.ViewComponents.Content.FirstPage;
using EnduranceJudge.Gateways.Desktop.ViewComponents.Content.SecondPage;
using EnduranceJudge.Gateways.Desktop.ViewComponents.Navigation;
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

            this.regionManager.RegisterViewWithRegion(Menu.RegionName, typeof(Menu));
            this.regionManager.RegisterViewWithRegion(First.RegionName, typeof(First));
            this.regionManager.RegisterViewWithRegion(Second.RegionName, typeof(Second));
        }
    }
}

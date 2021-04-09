using EnduranceJudge.Application.Test;
using EnduranceJudge.Core.Interfaces;
using EnduranceJudge.Gateways.Desktop.Components;
using EnduranceJudge.Gateways.Desktop.Components.Content;
using EnduranceJudge.Gateways.Desktop.Components.Content.FirstPage;
using EnduranceJudge.Gateways.Desktop.Components.Content.SecondPage;
using EnduranceJudge.Gateways.Desktop.Components.Navigation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

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
            containerRegistry.RegisterForNavigation<First>();
            containerRegistry.RegisterForNavigation<Second>();
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

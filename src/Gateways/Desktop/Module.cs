using EnduranceJudge.Application.Test;
using EnduranceJudge.Core.Models;
using EnduranceJudge.Core.Utilities;
using EnduranceJudge.Gateways.Desktop.Components.Content.FirstPage;
using EnduranceJudge.Gateways.Desktop.Components.Content.SecondPage;
using EnduranceJudge.Gateways.Desktop.Components.Navigation;
using EnduranceJudge.Gateways.Desktop.Core;
using MediatR;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace EnduranceJudge.Gateways.Desktop
{
    public class Module : IModule
    {
        private static readonly Type ModuleType = typeof(Module);
        private readonly IRegionManager regionManager;

        public Module(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            this.RegisterViewsForNavigation(containerRegistry);
        }

        public async void OnInitialized(IContainerProvider containerProvider)
        {
            var mediator = containerProvider.Resolve<IMediator>();

            var test = new Test
            {
                Name = "TestName",
            };

            await mediator.Send(test);

            this.regionManager.RegisterViewWithRegion(Regions.Navigation, typeof(Menu));
            this.regionManager.RegisterViewWithRegion(Regions.Content, typeof(First));
            this.regionManager.RegisterViewWithRegion(Regions.Content, typeof(Second));
        }

        private void RegisterViewsForNavigation(IContainerRegistry containerRegistry)
        {
            var descriptors = this.GetViewDescriptors();

            foreach (var descriptor in descriptors)
            {
                containerRegistry.RegisterForNavigation(descriptor.Type, descriptor.Instance.RegionName);
            }
        }

        private IEnumerable<TypeDescriptor<IView>> GetViewDescriptors()
        {
            return ReflectionUtilities.GetDescriptors<IView>(ModuleType.Assembly);
        }
    }
}

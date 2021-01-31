using EnduranceContestManager.Application.Contests.Commands;
using EnduranceContestManager.Application.Contests.Queries.Details;
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


            var create = new CreateContest
            {
                Country = "Bege",
                Name = "Name",
                PresidentGroundJury = "President Ground",
                ActiveVet = "Active Vet",
                ForeignJudge = "Foreign Judge",
                PopulatedPlace = "Place",
                FeiTechDelegate = "Tech Delegate",
                FeiVetDelegate = "Vet Delegate",
                PresidentVetCommission = "President Vet",
            };

            var update = new UpdateContest()
            {
                Id = 1,
                Country = "Updated",
                Name = "Updated",
                PresidentGroundJury = "PUpdated resident Ground",
                ActiveVet = "Updated Active Vet",
                ForeignJudge = "UpdatedForeign Judge",
                PopulatedPlace = "Updated Place",
                FeiTechDelegate = "UpdatedTech Delegate",
                FeiVetDelegate = "Updated Vet Delegate",
                PresidentVetCommission = "Updated President Vet",
            };

            await mediator.Send(update);

            this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }
    }
}

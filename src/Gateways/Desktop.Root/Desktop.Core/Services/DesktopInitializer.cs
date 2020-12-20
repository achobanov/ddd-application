using AutoMapper;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Gateways.Desktop.Interfaces;
using System;
using System.Threading.Tasks;

namespace EnduranceContestManager.Gateways.Desktop.Core.Services
{
    public class DesktopInitializer : IInitializerInterface
    {
        private readonly IMapper mapper;

        public DesktopInitializer(IMapper mapper)
            => this.mapper = mapper;

        public Task Run(IServiceProvider serviceProvider)
        {
            this.ConfigureMappingApi();

            return Task.CompletedTask;
        }

        private void ConfigureMappingApi()
            => MappingApi.Configure(this.mapper);
    }
}
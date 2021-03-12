using AutoMapper;
using EnduranceJudge.Core.Interfaces;
using EnduranceJudge.Core.Mappings;
using System;
using System.Threading.Tasks;

namespace EnduranceJudge.Gateways.Desktop.Startup
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
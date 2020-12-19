using System;
using System.Threading.Tasks;
using AutoMapper;
using EnduranceContestManager.Common.Mappings;
using EnduranceContestManager.Gateways.Web.Contracts;

namespace EnduranceContestManager.Gateways.Web.Startup
{
    public class WebInitializer : IInitializer
    {
        private readonly IMapper mapper;

        public WebInitializer(IMapper mapper)
            => this.mapper = mapper;

        public Task Initialize(IServiceProvider serviceProvider)
        {
            this.ConfigureMappingApi();

            return Task.CompletedTask;
        }

        public void ConfigureMappingApi()
            => MappingApi.Configure(this.mapper);
    }
}

using System;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Common.Mappings;
using Blog.Gateways.Web.Contracts;

namespace Blog.Gateways.Web.Startup
{
    public class WebInitialization : IInitializtion
    {
        private readonly IMapper mapper;

        public WebInitialization(IMapper mapper)
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

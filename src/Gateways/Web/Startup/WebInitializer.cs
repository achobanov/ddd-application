using System;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Common.Mappings;
using Blog.Gateways.Web.Contracts;

namespace Blog.Gateways.Web.Startup
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

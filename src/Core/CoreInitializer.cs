using AutoMapper;
using EnduranceJudge.Core.Interfaces;
using EnduranceJudge.Core.Mappings;
using System;
using System.Threading.Tasks;

namespace EnduranceJudge.Core
{
    public class CoreInitializer : IInitializerInterface
    {
        private readonly IMapper mapper;

        public CoreInitializer(IMapper mapper)
            => this.mapper = mapper;

        public int Order { get; } = 0;

        public Task Run(IServiceProvider serviceProvider)
        {
            MappingApi.Initialize(this.mapper);

            return Task.CompletedTask;
        }
    }
}

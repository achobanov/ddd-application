namespace Blog.Application.UnitTests.Common.Mappings
{
    using AutoMapper;
    using Blog.Common.Mappings;

    public class MappingTestsFixture
    {
        public MappingTestsFixture()
        {
            this.ConfigurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationMappingProfile>();
            });

            this.Mapper = this.ConfigurationProvider.CreateMapper();
        }

        public IConfigurationProvider ConfigurationProvider { get; }

        public IMapper Mapper { get; }
    }
}

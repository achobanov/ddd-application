namespace Blog.Application.UnitTests.Common.Mappings
{
    using AutoMapper;
    using System;
    using Xunit;
    using Blog.Application.Articles.Queries;
    using Blog.Domain.Articles;

    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider configuration;
        private readonly IMapper mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            this.configuration = fixture.ConfigurationProvider;
            this.mapper = fixture.Mapper;
        }

        [Theory]
        [InlineData(typeof(Article), typeof(ArticleDetailsModel))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            this.mapper.Map(instance, source, destination);
        }
    }
}

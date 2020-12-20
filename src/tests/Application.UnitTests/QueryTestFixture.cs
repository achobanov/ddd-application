using System;
using AutoMapper;
using EnduranceContestManager.Application;
using EnduranceContestManager.Application.Core;
using EnduranceContestManager.Gateways.Persistence.Providers;
using Xunit;

namespace Blog.Application.UnitTests
{
    // Tests will be fixed in: https://github.com/achobanov/web-application/issues/21
    public sealed class QueryTestFixture : IDisposable
    {
        public QueryTestFixture()
        {
            this.Context = ApplicationDbContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationMappingProfile>();
            });

            this.Mapper = configurationProvider.CreateMapper();

            //var identityMock = new Mock<IIdentity>();

            //identityMock
            //    .Setup(i => i.GetUserName(It.IsAny<string>()))
            //    .Returns(Task.FromResult("Test User"));

            //this.Identity = identityMock.Object;
        }

        public ContestDbContext Context { get; }

        public IMapper Mapper { get; }

        // public IIdentity Identity { get; }

        public void Dispose() => ApplicationDbContextFactory.Destroy(this.Context);
    }

    [CollectionDefinition("QueryTests")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
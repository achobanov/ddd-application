using System;
using Blog.Application.Contracts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Blog.Common.Contracts;
using Blog.Domain.Articles;
using Blog.Gateways.Persistence.Providers;

namespace Blog.Application.UnitTests
{
    public abstract class BaseTests : IDisposable
    {
        private DbContext dbContext;

        public BaseTests()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var operationalStoreOptions = Options.Create(
                new OperationalStoreOptions
                {
                    DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                    PersistedGrants = new TableConfiguration("PersistedGrants")
                });

            var dateTimeMock = new Mock<IDateTime>();
            var authenticationContextMock = new Mock<IAuthenticationContext>();

            this.dbContext = new BlogDbContext(
                options,
                operationalStoreOptions,
                authenticationContextMock.Object,
                dateTimeMock.Object);

            this.dbContext.Database.EnsureCreated();

            this.SeedSampleData();

            this.DateTimeMock = dateTimeMock;
            this.AuthenticationContextMock = authenticationContextMock;
        }

        protected IPersistenceContract Persistence => (IPersistenceContract)this.dbContext;

        protected Mock<IDateTime> DateTimeMock { get; }

        protected Mock<IAuthenticationContext> AuthenticationContextMock { get; }

        public void Dispose()
        {
            this.dbContext.Database.EnsureDeleted();

            this.dbContext.Dispose();
        }

        private void SeedSampleData()
        {
            this.Persistence
                .Set<Article>()
                .AddRange(
                    new Article("Test Title 1", "Test Content 1") { CreatedBy = "Test User 1" },
                    new Article("Test Title 2", "Test Content 2") { CreatedBy = "Test User 2" },
                    new Article("Test Title 3", "Test Content 3") { CreatedBy = "Test User 3" });

            this.Persistence.SaveChanges();
        }
    }
}
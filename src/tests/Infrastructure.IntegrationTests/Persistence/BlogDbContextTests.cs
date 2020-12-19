using EnduranceContestManager.Application.Contracts;
using EnduranceContestManager.Common.Contracts;
using EnduranceContestManager.Domain.Articles;
using EnduranceContestManager.Gateways.Persistence.Providers;
using System;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Shouldly;
using Xunit;

namespace Blog.Infrastructure.IntegrationTests.Persistence
{
    public class ContestDbContextTests : IDisposable
    {
        private readonly string username;
        private readonly DateTime dateTime;
        private readonly ContestDbContext data;

        public ContestDbContextTests()
        {
            this.dateTime = new DateTime(3001, 1, 1);

            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.SetupGet(dt => dt.Now).Returns(this.dateTime);

            this.username = "mevolent";
            var authenticationMock = new Mock<IAuthenticationContext>();
            authenticationMock.Setup(m => m.Username).Returns(this.username);

            var options = new DbContextOptionsBuilder<ContestDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var operationalStoreOptions = Options.Create(
                new OperationalStoreOptions
                {
                    DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                    PersistedGrants = new TableConfiguration("PersistedGrants")
                });

            this.data = new ContestDbContext(options, operationalStoreOptions, authenticationMock.Object, dateTimeMock.Object);

            this.data.Articles.Add(new Article("Test Title", "Test Content") { CreatedBy = this.username });

            this.data.SaveChanges();
        }

        [Fact]
        public async Task SaveChangesAsyncGivenNewArticleShouldSetCreatedProperties()
        {
            var article = new Article("Test Title 2", "Test Content 2") { CreatedBy = this.username };

            this.data.Articles.Add(article);

            await this.data.SaveChangesAsync();

            article.CreatedOn.ShouldBe(this.dateTime);
            article.CreatedBy.ShouldBe(this.username);
        }

        [Fact]
        public async Task SaveChangesAsyncGivenExistingArticleShouldSetModifiedProperties()
        {
            var article = await this.data.Articles.FindAsync(1);

            article.Title = "New Test Title";

            await this.data.SaveChangesAsync();

            article.ModifiedOn.ShouldNotBeNull();
            article.ModifiedOn.ShouldBe(this.dateTime);
            article.ModifiedBy.ShouldBe(this.username);
        }

        public void Dispose() => this.data?.Dispose();
    }
}

namespace Blog.Infrastructure.IntegrationTests.Persistence
{
    using System;
    using System.Threading.Tasks;
    using Blog.Application.Contracts;
    using IdentityServer4.EntityFramework.Options;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Moq;
    using Shouldly;
    using Xunit;
    using Blog.Common.Contracts;
    using Blog.Domain.Articles;
    using Blog.Gateways.Persistence.Providers;

    public class BlogDbContextTests : IDisposable
    {
        private readonly string username;
        private readonly DateTime dateTime;
        private readonly BlogDbContext data;

        public BlogDbContextTests()
        {
            this.dateTime = new DateTime(3001, 1, 1);

            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.SetupGet(dt => dt.Now).Returns(this.dateTime);

            this.username = "mevolent";
            var authenticationMock = new Mock<IAuthenticationContext>();
            authenticationMock.Setup(m => m.Username).Returns(this.username);

            var options = new DbContextOptionsBuilder<BlogDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var operationalStoreOptions = Options.Create(
                new OperationalStoreOptions
                {
                    DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                    PersistedGrants = new TableConfiguration("PersistedGrants")
                });

            this.data = new BlogDbContext(options, operationalStoreOptions, authenticationMock.Object, dateTimeMock.Object);

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

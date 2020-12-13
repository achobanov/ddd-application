using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Application.Articles.Queries;
using Blog.Gateways.Persistence.Providers;
using Shouldly;
using Xunit;

namespace Blog.Application.UnitTests.Articles.Queries.Details
{
    [Collection("QueryTests")]
    public class GetArticleDetailsTests
    {
        private readonly BlogDbContext context;

        public GetArticleDetailsTests(QueryTestFixture fixture)
            => this.context = fixture.Context;

        [Fact]
        public async Task HandleReturnsCorrectArticleDetails()
        {
            // Assert
            var query = new GetArticleDetails { Id = 1 };

            var handler = new GetArticleDetails.GetArticleDetailsHandler(this.context);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Id.ShouldBe(1);
            result.Title.ShouldBe("Test Title 1");
            result.Author.ShouldBe("Test User");
        }
    }
}

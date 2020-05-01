using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Articles.Queries;
using Shouldly;
using Xunit;

namespace Blog.Application.UnitTests.Articles.Queries.Details
{
    [Collection("QueryTests")]
    public class GetArticleDetailsTests : BaseTests
    {
        [Fact]
        public async Task HandleReturnsCorrectArticleDetails()
        {
            var query = new GetArticleDetails { Id = 1 };
            var handler = new GetArticleDetails.GetArticleDetailsHandler(this.Persistence);

            var result = await handler.Handle(query, CancellationToken.None);

            result.Id.ShouldBe(1);
            result.Title.ShouldBe("Test Title 1");
            result.Author.ShouldBe("Test User");
        }
    }
}

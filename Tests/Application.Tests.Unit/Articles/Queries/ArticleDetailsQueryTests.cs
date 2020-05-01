using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Articles.Queries;
using Shouldly;
using Xunit;

namespace Blog.Application.Tests.Unit.Articles.Queries
{
    [Collection("QueryTests")]
    public class GetArticleDetailsTests : BaseTests
    {
        [Fact]
        public async Task Handle_ShouldReturnArticleDetails()
        {
            var query = new GetArticleDetails { Id = 1 };
            var handler = new GetArticleDetails.GetArticleDetailsHandler(this.Persistence);

            var result = await handler.Handle(query, CancellationToken.None);

            // result is null here, becasue ProjectTo returns null under Xunit execution
            // AutoMapper issue: https://github.com/AutoMapper/AutoMapper/issues/3399
            result.Id.ShouldBe(1);
            result.Title.ShouldBe("Test Title 1");
            result.Author.ShouldBe("Test User");
        }
    }
}

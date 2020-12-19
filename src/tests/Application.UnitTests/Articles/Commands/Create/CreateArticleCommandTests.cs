using EnduranceContestManager.Application.Articles.Commands;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Blog.Application.UnitTests.Articles.Commands.Create
{

    public class CreateArticleTests : CommandTestBase
    {
        [Fact]
        public async Task HandleShouldPersistArticle()
        {
            var command = new CreateArticle
            {
                Title = "Test Title Command",
                Content = "Test Content Command"
            };

            var handler = new CreateArticle.CreateArticleHandler(this.Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var article = this.Context.Articles.Find(result);

            article.ShouldNotBeNull();
            article.Title.ShouldBe(command.Title);
            article.CreatedBy.ShouldBe(TestUserId);
        }
    }
}

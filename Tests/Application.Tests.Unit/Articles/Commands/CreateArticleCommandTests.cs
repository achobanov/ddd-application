using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Articles.Commands;
using Blog.Domain.Articles;
using Shouldly;
using Xunit;

namespace Blog.Application.Tests.Unit.Articles.Commands
{
    public class CreateArticleTests : BaseTests
    {
        [Fact]
        public async Task Handle_ShouldPersistArticle()
        {
            var command = new CreateArticle
            {
                Title = "Test Title Command",
                Content = "Test Content Command"
            };

            var handler = new CreateArticle.CreateArticleHandler(this.Persistence);

            var result = await handler.Handle(command, CancellationToken.None);

            var article = await this.Persistence.Set<Article>().Find(result);

            article.ShouldNotBeNull();
            article.Title.ShouldBe(command.Title);
            article.CreatedBy.ShouldBe(SampleUsername);
        }
    }
}

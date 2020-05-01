namespace Blog.Application.UnitTests.Articles.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Blog.Application.Articles.Commands;
    using Blog.Domain.Articles;
    using Shouldly;
    using Xunit;

    public class CreateArticleTests : BaseTests
    {
        [Fact]
        public async Task HandleShouldPersistArticle()
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

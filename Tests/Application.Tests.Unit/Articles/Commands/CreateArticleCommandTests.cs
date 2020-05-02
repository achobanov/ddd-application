using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Articles.Commands;
using Blog.Application.Contracts;
using Blog.Domain.Articles;
using Moq;
using Shouldly;
using Xunit;

namespace Blog.Application.Tests.Unit.Articles.Commands
{
    public class CreateArticleTests : BaseTests
    {
        private readonly Mock<IAuthenticationContext> AuthenticationContextMock;

        public CreateArticleTests()
        {
            this.AuthenticationContextMock = new Mock<IAuthenticationContext>();
        }

        [Fact]
        public async Task Handle_ShouldPersistArticle()
        {
            var command = new CreateArticle
            {
                Title = "Test Title Command",
                Content = "Test Content Command"
            };

            var handler = new CreateArticle.CreateArticleHandler(
                this.Persistence,
                this.AuthenticationContextMock.Object);

            this.AuthenticationContextMock
                .SetupGet(x => x.Username)
                .Returns(SampleUsername);

            var result = await handler.Handle(command, CancellationToken.None);

            var article = await this.Persistence.Set<Article>().Find(result);

            article.ShouldSatisfyAllConditions(
                () => article.ShouldNotBeNull(),
                () => article.Title.ShouldBe(command.Title),
                () => article.Author.Username.ShouldBe(SampleUsername));
        }
    }
}

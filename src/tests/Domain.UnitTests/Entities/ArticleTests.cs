using EnduranceContestManager.Domain.Articles;
using Xunit;

namespace Blog.Domain.UnitTests.Entities
{
    public class ArticleTests
    {
        [Fact]
        public void TitleShouldThrowExceptionWhenNull()
        {
            // Assert
            Assert.Throws<ArticleException>(
                () => new Article(null, "Test Content"));
        }

        [Fact]
        public void UserIdShouldThrowExceptionWhenNull()
        {
            // Assert
            Assert.Throws<ArticleException>(
                () => new Article("Test Title", "Test Content"));
        }
    }
}

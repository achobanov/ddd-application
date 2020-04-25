namespace Blog.Domain.UnitTests.Entities
{
    using Blog.Domain.Articles;
    using Xunit;

    public class ArticleTests
    {
        [Fact]
        public void TitleShouldThrowExceptionWhenNull()
        {
            // Assert
            Assert.Throws<ArticleException>(
                () => new Article(null, "Test Content", "Test Id"));
        }

        [Fact]
        public void UserIdShouldThrowExceptionWhenNull()
        {
            // Assert
            Assert.Throws<ArticleException>(
                () => new Article("Test Title", "Test Content", null));
        }
    }
}

using Blog.Domain.Articles;
using Moq;
using Xunit;

namespace Blog.Domain.Tests.Unit
{
    public class ArticleTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Title_ShouldNotBeNull(string title)
            => Assert.Throws<ArticleException>(
                () => new Article(title, It.IsAny<string>(), It.IsAny<int>()));

        [Theory]
        [InlineData(41)]
        [InlineData(100)]
        public void Title_ShouldBeOfValidLength(int length)
            => Assert.Throws<ArticleException>(
                () => new Article(new string('x', length), It.IsAny<string>(), It.IsAny<int>()));

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Content_ShouldNotBeNullOrEmpty(string content)
            => Assert.Throws<ArticleException>(
                () => new Article(It.IsAny<string>(), content, It.IsAny<int>()));
    }
}

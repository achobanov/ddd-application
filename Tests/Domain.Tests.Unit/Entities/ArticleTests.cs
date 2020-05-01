using Blog.Domain.Articles;
using Xunit;

namespace Blog.Domain.Tests.Unit.Entities
{
    public class ArticleTests
    {
        private const string SampleText = "Sample text";

        [Fact]
        public void Title_ShouldNotBeNull()
            => Assert.Throws<ArticleException>(
                () => new Article(null, SampleText));

        [Fact]
        public void Title_ShouldNotBeEmpty()
            => Assert.Throws<ArticleException>(
                () => new Article(string.Empty, SampleText));

        [Theory]
        [InlineData(41)]
        [InlineData(100)]
        public void Title_ShouldBeOfValidLength(int length)
            => Assert.Throws<ArticleException>(
                () => new Article(new string('x', length), SampleText));

        [Fact]
        public void Content_ShouldNotBeNull()
            => Assert.Throws<ArticleException>(
                () => new Article(SampleText, null));

        [Fact]
        public void Content_ShouldNotBeEmpty()
            => Assert.Throws<ArticleException>(
                () => new Article(SampleText, string.Empty));
    }
}

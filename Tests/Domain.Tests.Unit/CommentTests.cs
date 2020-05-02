using Blog.Domain.Articles;
using Blog.Domain.Comments;
using Xunit;

namespace Blog.Domain.Tests.Unit
{
    public class CommentTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Content_ShouldNotBeNull(string comment)
            => Assert.Throws<CommentException>(
                () => new Article("Some title", "Some content", 1).AddComment(comment, 1));
    }
}

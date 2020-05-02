using Blog.Domain.Comments;
using Xunit;

namespace Blog.Domain.Tests.Unit
{
    public class CommentTests
    {
        [Fact]
        public void Content_ShouldNotBeNull()
            => Assert.Throws<CommentException>(
                () => new Comment(null, articleId: 1, authorId: 1));

        [Fact]
        public void Content_ShouldNotBeEmpty()
            => Assert.Throws<CommentException>(
                () => new Comment(string.Empty, articleId: 1, authorId: 1));
    }
}

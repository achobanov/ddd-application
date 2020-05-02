using Blog.Domain.Authors;
using Shouldly;
using Xunit;

namespace Blog.Domain.Tests.Unit
{
    public class AuthorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Username_ShouldNotBeNullOrEmpty(string username)
            => Assert.Throws<AuthorException>(
                () => new Author(null));

        [Fact]
        public void SetUser_ShouldThrowIfUsernameIsAlreadySet()
            => Assert.Throws<AuthorException>(
                () => new Author("username").SetUser("second-username"));

        [Fact]
        public void SetUser_ShouldSetAuthorUsername()
        {
            var author = new Author();

            var username = "username";

            author.SetUser(username);

            author.Username.ShouldBe(username);
        }
    }
}

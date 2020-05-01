namespace Blog.Application.UnitTests
{
    public abstract class BaseCommandTests : BaseTests
    {
        protected const string SampleUsername = "Sample Username";

        public BaseCommandTests()
            => this.AuthenticationContextMock
                .SetupGet(u => u.Username)
                .Returns(SampleUsername);
    }
}
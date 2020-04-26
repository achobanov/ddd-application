namespace Blog.Application.UnitTests
{
    using System;
    using Blog.Application.Contracts;
    using Blog.Gateways.Persistence.Providers;
    using Moq;

    public class CommandTestBase : IDisposable
    {
        protected const string TestUserId = "Test User Id";

        public CommandTestBase()
        {
            this.Context = ApplicationDbContextFactory.Create();

            var currentUserMock = new Mock<IAuthenticationContract>();

            currentUserMock
                .SetupGet(u => u.Username)
                .Returns(TestUserId);

            this.IdentityContext = currentUserMock.Object;
        }

        public BlogDbContext Context { get; }

        public IAuthenticationContract IdentityContext { get; }

        public void Dispose() => ApplicationDbContextFactory.Destroy(this.Context);
    }
}
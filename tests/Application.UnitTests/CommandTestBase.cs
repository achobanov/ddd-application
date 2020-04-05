namespace Blog.Application.UnitTests
{
    using System;
    using Blog.Application.Contracts;
    using Infrastructure.Persistence;
    using Moq;

    public class CommandTestBase : IDisposable
    {
        protected const string TestUserId = "Test User Id";

        public CommandTestBase()
        {
            this.Context = ApplicationDbContextFactory.Create();

            var currentUserMock = new Mock<IIdentityContext>();

            currentUserMock
                .SetupGet(u => u.UserId)
                .Returns(TestUserId);

            this.IdentityContext = currentUserMock.Object;
        }

        public BlogDbContext Context { get; }

        public IIdentityContext IdentityContext { get; }

        public void Dispose() => ApplicationDbContextFactory.Destroy(this.Context);
    }
}
using EnduranceContestManager.Application.Interfaces;
using EnduranceContestManager.Gateways.Persistence.Providers;

namespace Blog.Application.UnitTests
{
    using System;
    using Moq;

    public class CommandTestBase : IDisposable
    {
        protected const string TestUserId = "Test User Id";

        public CommandTestBase()
        {
            this.Context = ApplicationDbContextFactory.Create();

            var currentUserMock = new Mock<IAuthenticationContext>();

            currentUserMock
                .SetupGet(u => u.Username)
                .Returns(TestUserId);

            this.IdentityContext = currentUserMock.Object;
        }

        public ContestDbContext Context { get; }

        public IAuthenticationContext IdentityContext { get; }

        public void Dispose() => ApplicationDbContextFactory.Destroy(this.Context);
    }
}
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
        }

        public ContestDbContext Context { get; }

        public void Dispose() => ApplicationDbContextFactory.Destroy(this.Context);
    }
}
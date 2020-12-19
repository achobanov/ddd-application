using System;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using EnduranceContestManager.Application.Contracts;
using EnduranceContestManager.Common.Contracts;
using EnduranceContestManager.Domain.Articles;
using EnduranceContestManager.Gateways.Persistence.Providers;

namespace Blog.Application.UnitTests
{
    public static class ApplicationDbContextFactory
    {
        public static ContestDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ContestDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var operationalStoreOptions = Options.Create(
                new OperationalStoreOptions
                {
                    DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                    PersistedGrants = new TableConfiguration("PersistedGrants")
                });

            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now)
                .Returns(new DateTime(3001, 1, 1));

            var currentUserServiceMock = new Mock<IAuthenticationContext>();
            currentUserServiceMock.Setup(m => m.Username)
                .Returns("00000000-0000-0000-0000-000000000000");

            var context = new ContestDbContext(
                options, operationalStoreOptions,
                currentUserServiceMock.Object, dateTimeMock.Object);

            context.Database.EnsureCreated();

            SeedSampleData(context);

            return context;
        }

        public static void SeedSampleData(ContestDbContext context)
        {
            context.Articles.AddRange(
                new Article("Test Title 1", "Test Content 1") { CreatedBy = "Test User 1" },
                new Article("Test Title 2", "Test Content 2") { CreatedBy = "Test User 2" },
                new Article("Test Title 3", "Test Content 3") { CreatedBy = "Test User 3" });

            context.SaveChanges();
        }

        public static void Destroy(ContestDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
using System;
using Microsoft.AspNetCore.Identity;
using MyTested.AspNetCore.Mvc;
using EnduranceContestManager.Domain.Articles;

namespace Blog.Web.IntegrationTests
{
    public class TestData
    {
        public static DateTime TestNow => new DateTime(3000, 10, 10);

        public static object[] Articles
            => new object[]
            {
                new Article("Test Title 1", "Test Content 1")
                {
                    Id = 1,
                    IsPublic = false,
                    CreatedBy = TestUser.Identifier
                },
                new Article("Test Title 2", "Test Content 2")
                {
                    Id = 2,
                    CreatedBy = TestUser.Identifier,
                },
                new IdentityUser
                {
                    Id = TestUser.Identifier,
                    UserName = TestUser.Username
                }
            };
    }
}

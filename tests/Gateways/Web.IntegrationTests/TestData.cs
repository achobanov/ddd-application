using System;
using Blog.Domain.Articles;
using Microsoft.AspNetCore.Identity;
using MyTested.AspNetCore.Mvc;

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
                    CreatedBy = TestUser.Username
                },
                new Article("Test Title 2", "Test Content 2")
                {
                    Id = 2,
                    CreatedBy = TestUser.Username,
                },
                new IdentityUser
                {
                    Id = TestUser.Identifier,
                    UserName = TestUser.Username
                }
            };
    }
}

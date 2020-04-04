namespace Blog.Web.IntegrationTests
{
    using System;
    using Domain.Entities;
    using Microsoft.AspNetCore.Identity;
    using MyTested.AspNetCore.Mvc;

    public class TestData
    {
        public static DateTime TestNow => new DateTime(3000, 10, 10);

        public static object[] Articles
            => new object[]
            {
                new Article("Test Title 1", "Test Content 1", TestUser.Identifier)
                {
                    Id = 1,
                    IsPublic = false
                },
                new Article("Test Title 2", "Test Content 2", TestUser.Identifier)
                {
                    Id = 2
                },
                new IdentityUser
                {
                    Id = TestUser.Identifier,
                    UserName = TestUser.Username
                }
            };
    }
}

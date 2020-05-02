using System;
using Blog.Domain.Articles;
using Blog.Domain.Authors;
using Microsoft.AspNetCore.Identity;
using MyTested.AspNetCore.Mvc;

namespace Blog.Web.Tests.Integration
{
    public class TestData
    {
        public static DateTime TestNow => new DateTime(3000, 10, 10);

        public static object[] Articles
            => new object[]
            {
                new Author(TestUser.Username)
                {
                    Id = 1
                },
                new Article("Test Title 1", "Test Content 1", authorId: 1)
                {
                    Id = 1,
                    IsPublic = false,
                    CreatedBy = TestUser.Username
                },
                new Article("Test Title 2", "Test Content 2", authorId: 1)
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

using EnduranceContestManager.Application.Articles.Commands;
using EnduranceContestManager.Application.Articles.Queries;
using EnduranceContestManager.Gateways.Persistence.Providers;
using EnduranceContestManager.Gateways.Web.Areas.Api;
using Shouldly;
using System.Linq;

namespace Blog.Web.IntegrationTests.Features
{
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ArticlesControllerTests
    {
        [Fact]
        public void ArticleControllerShouldBeForAuthorizedUsers()
            => MyController<ArticlesController>
                .ShouldHave()
                .Attributes(attr => attr
                    .RestrictingForAuthorizedRequests());

        [Fact]
        public void DetailsShouldBeAllowedForAnonymousUsersAndGetRequestsOnly()
            => MyController<ArticlesController>
                .Calling(c => c.Details(With.Default<GetArticleDetails>()))
                .ShouldHave()
                .ActionAttributes(attr => attr
                    .AllowingAnonymousRequests()
                    .RestrictingForHttpMethod(HttpMethod.Get));

        [Theory]
        [InlineData(1)]
        public void DetailsShouldReturnCorrectArticleDetailsOutputModelWithValidData(int id)
            => MyController<ArticlesController>
                .Instance(controller => controller
                    .WithData(entities => entities
                        .WithEntities<ContestDbContext>(TestData.Articles)))
                .Calling(c => c.Details(new GetArticleDetails { Id = id }))
                .ShouldReturn()
                .ActionResult<ArticleDetailsModel>(result => result
                    .Passing(model => model.Id == id && model.Author == TestUser.Username));

        [Theory]
        [InlineData("Test Title", "Test Content")]
        public void CreateShouldSaveArticleToTheDatabaseAndReturnCorrectArticleId(string title, string content)
            => MyController<ArticlesController>
                .Instance(controller => controller
                    .WithData(entities => entities
                        .WithEntities<ContestDbContext>(TestData.Articles)))
                .Calling(c => c.Create(new CreateArticle
                {
                    Title = title,
                    Content = content
                }))
                .ShouldHave()
                .Data(data => data
                    .WithEntities<ContestDbContext>(entities =>
                    {
                        entities.Articles.Count().ShouldBe(3);

                        entities
                            .Articles
                            .FirstOrDefault(a =>
                                a.Title == title &&
                                a.Content == content &&
                                a.CreatedBy == TestUser.Identifier &&
                                a.CreatedOn == TestData.TestNow)
                            .ShouldNotBeNull();
                    }))
                .AndAlso()
                .ShouldReturn()
                .ActionResult<int>(result => result
                    .Passing(model => model != 0));
    }
}

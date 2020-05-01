using System.Linq;
using MyTested.AspNetCore.Mvc;
using Shouldly;
using Xunit;
using Blog.Application.Articles.Commands;
using Blog.Application.Articles.Queries;
using Blog.Gateways.Web.Areas.Api;
using Blog.Gateways.Persistence.Providers;
using Blog.Domain.Articles;

namespace Blog.Web.IntegrationTests.Api
{
    public class ArticlesControllerTests
    {
        [Theory]
        [InlineData(1)]
        public void Details_ShouldReturnCorrectArticleDetailsModelWithValidData(int id)
            => MyController<ArticlesController>
                .Instance(controller =>
                    controller.WithData(TestData.Articles))
                .Calling(c =>
                    c.Details(new GetArticleDetails { Id = id }))
                .ShouldReturn()
                .ActionResult<ArticleDetailsModel>(result =>
                    result.Passing(model => model.Id == id && model.Author == TestUser.Username));

        [Theory]
        [InlineData("Test Title", "Test Content")]
        public void CreateShouldSaveArticleToTheDatabaseAndReturnCorrectArticleId(string title, string content)
            => MyController<ArticlesController>
                .Instance(controller =>
                    controller.WithData(TestData.Articles))
                .Calling(c =>
                    c.Create(new CreateArticle
                    {
                        Title = title,
                        Content = content
                    }))
                .ShouldHave()
                .Data(data =>
                    data.WithEntities(entities =>
                    {
                        var articles = entities.Set<Article>();

                        var articlesCount = articles.Count();

                        var newArticle = articles.FirstOrDefault(a =>
                            a.Title == title
                            && a.Content == content
                            && a.CreatedBy == TestUser.Username
                            && a.CreatedOn == TestData.TestNow);

                        articles.ShouldSatisfyAllConditions(
                            () => articlesCount.ShouldBe(3),
                            () => newArticle.ShouldNotBeNull());
                    }))
                .AndAlso()
                .ShouldReturn()
                .ActionResult<int>(result =>
                    result.Passing(model => model != 0));
    }
}

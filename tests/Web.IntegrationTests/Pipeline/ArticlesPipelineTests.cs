using System.Linq;
using Blog.Application.Articles.Commands;
using Blog.Domain.Articles;
using Blog.Gateways.Web.Areas.Api;
using MyTested.AspNetCore.Mvc;
using Shouldly;
using Xunit;

namespace Blog.Web.IntegrationTests.Pipeline
{
    public class ArticlesPipelineTests
    {
        [Theory]
        [InlineData(1)]
        public void ChangeVisibilityShouldBeRoutedCorrectlyAndShouldReturnNoContent(int id)
            => MyPipeline
                .Configuration()
                .ShouldMap(request =>
                    request
                        .WithMethod(HttpMethod.Put)
                        .WithLocation("api/Articles/ChangeVisibility")
                        .WithJsonBody(new { Id = id }))
                .To<ArticlesController>(c =>
                    c.ChangeVisibility(new ChangeArticleVisibility { Id = id }))
                .Which(controller =>
                    controller.WithData(TestData.Articles))
                .ShouldHave()
                .Data(data =>
                    data.WithEntities(entities =>
                        entities
                            .Set<Article>()
                            .FirstOrDefault(a => a.Id == id && a.IsPublic)
                            .ShouldNotBeNull()))
                .AndAlso()
                .ShouldReturn()
                .NoContent();
    }
}

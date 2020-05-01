using Blog.Application.Articles.Commands;
using Blog.Application.Articles.Queries;
using Blog.Gateways.Web.Areas.Api;
using MyTested.AspNetCore.Mvc;
using Xunit;

namespace Blog.Web.Tests.Integration.Routing
{
    public class ArticlesRoutingTests
    {
        [Fact]
        public void Details()
            => MyRouting
                .Configuration()
                .ShouldMap("api/Articles/1")
                .To<ArticlesController>(c => c.Details(new GetArticleDetails { Id = 1 }));

        [Theory]
        [InlineData("Test Title", "Test Content")]
        public void Create(string title, string content)
            => MyRouting
                .Configuration()
                .ShouldMap(request =>
                    request
                        .WithMethod(HttpMethod.Post)
                        .WithLocation("api/Articles")
                        .WithJsonBody(new
                        {
                            Title = title,
                            Content = content
                        }))
                .To<ArticlesController>(c =>
                    c.Create(new CreateArticle
                    {
                        Title = title,
                        Content = content
                    }));

        [Theory]
        [InlineData(1)]
        public void ChangeVisibility(int id)
            => MyRouting
                .Configuration()
                .ShouldMap(request =>
                    request
                        .WithMethod(HttpMethod.Put)
                        .WithLocation("api/Articles/ChangeVisibility")
                        .WithJsonBody(new { Id = id }))
                .To<ArticlesController>(c =>
                    c.ChangeVisibility(new ChangeArticleVisibility
                    {
                        Id = id
                    }));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Application;
using Blog.Application.Articles.Queries;
using Blog.Common.Mappings;
using Blog.Domain.Articles;
using Blog.Domain.Comments;
using Moq;
using Shouldly;
using Xunit;

namespace Blog.Common.Tests.Unit
{
    public class MappingApiTests
    {
        private const string SampleTitle = "Sample title";
        private const string SampleContent = "Sample content";
        private const int SampleAuthorId = 1;

        [Fact]
        public void Map_WhenNotConfigured_ShouldThrowInvalidOperation()
            => Assert.Throws<InvalidOperationException>(
                () => new Article(
                    SampleTitle,
                    SampleContent,
                    SampleAuthorId).Map<ArticleDetailsModel>());

        [Fact]
        public void Map_ShouldMapPropertiesByConvention()
        {
            var title = "some title";
            var content = "some content";
            var authorId = 1;

            this.Configure();

            var article = new Article(title, content, authorId);
            var mapped = article.Map<ArticleDetailsModel>();

            mapped.ShouldSatisfyAllConditions(
                () => mapped.Title.ShouldBe(article.Title),
                () => mapped.Content.ShouldBe(article.Content));
        }

        [Fact]
        public void Map_ShouldMapExplicitProperties()
        {
            var title = "some title";
            var content = "some content";
            var authorId = 1;

            this.Configure();

            var article = new Article(title, content, authorId);

            article.AddComment("some comment", authorId);
            article.AddComment("second comment", authorId);

            var mapped = article.Map<ArticleDetailsModel>();

            mapped.CommmentsCount.ShouldBe(article.Comments.Count());
        }

        [Fact]
        public void MapTask_WhenNotConfigured_ShouldThrowInvalidOperation()
            => Assert.ThrowsAsync<InvalidOperationException>(
                () => Task
                    .FromResult(new Article(SampleTitle, SampleContent, SampleAuthorId))
                    .Map<ArticleDetailsModel>());

        [Fact]
        public void MapCollection_WhenNotConfigured_ShouldThrowInvalidOperation()
            => Assert.Throws<InvalidOperationException>(
                () =>
                {
                    var article = new Article(SampleTitle, SampleContent, SampleAuthorId);
                    var articlesList = new List<Article> { article };

                    articlesList.MapCollection<ArticleDetailsModel>();
                });

        [Fact]
        public void MapCollectionTask_WhenNotConfigured_ShouldThrowInvalidOperation()
            => Assert.ThrowsAsync<InvalidOperationException>(
                () =>
                {
                    var article = new Article(SampleTitle, SampleContent, SampleAuthorId);
                    var articlesList = new List<Article> { article };

                    return Task
                        .FromResult(articlesList)
                        .MapCollection<ArticleDetailsModel>();
                });

        [Fact]
        public void MapCollectionTask_WhenUserOnNonEnumerableTask_ShouldThrowArgument()
            => Assert.ThrowsAsync<ArgumentException>(
                () =>
                {
                    var article = new Article(SampleTitle, SampleContent, SampleAuthorId);

                    return Task
                        .FromResult(article)
                        .MapCollection<ArticleDetailsModel>();
                });

        [Fact]
        public void MapQueryable_WhenNotConfigured_ShouldThrowInvalidOperation()
            => Assert.Throws<InvalidOperationException>(
                () =>
                {
                    var article = new Article(SampleTitle, SampleContent, SampleAuthorId);
                    var articlesList = new List<Article> { article };

                    articlesList
                        .AsQueryable()
                        .MapCollection<ArticleDetailsModel>();
                });

        private void Configure()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationMappingProfile>();
            });

            var mapper = configurationProvider.CreateMapper();
            MappingApi.Configure(mapper);
        }
    }
}

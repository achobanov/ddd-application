namespace Blog.Application.UnitTests.Articles.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Articles.Queries.Details;
    using AutoMapper;
    using Infrastructure.Persistence;
    using Shouldly;
    using Xunit;

    [Collection("QueryTests")]
    public class ArticleDetailsQueryTests
    {
        private readonly BlogDbContext context;
        private readonly IMapper mapper;

        public ArticleDetailsQueryTests(QueryTestFixture fixture)
        {
            this.context = fixture.Context;
            this.mapper = fixture.Mapper;
        }

        [Fact]
        public async Task HandleReturnsCorrectArticleDetails()
        {
            // Assert
            var query = new ArticleDetailsQuery { Id = 1 };

            var handler = new ArticleDetailsQuery.ArticleDetailsQueryHandler(this.context, this.mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Id.ShouldBe(1);
            result.Title.ShouldBe("Test Title 1");
            result.Author.ShouldBe("Test User");
        }
    }
}

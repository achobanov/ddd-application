using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Infrastructure.Handlers;
using Blog.Application.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Blog.Domain.Articles;
using Blog.Common.Mappings;

namespace Blog.Application.Articles.Queries
{
    public class GetArticleDetails : IRequest<ArticleDetailsModel>
    {
        public int Id { get; set; }

        public class GetArticleDetailsHandler : Handler<GetArticleDetails, ArticleDetailsModel>
        {
            private readonly IPersistenceContract data;

            public GetArticleDetailsHandler(IPersistenceContract data)
                => this.data = data;

            public override async Task<ArticleDetailsModel> Handle(
                GetArticleDetails request,
                CancellationToken cancellationToken)
            {
                var articles = await this.data
                    .Set<Article>()
                    .ToListAsync();

                var mapped = articles.MapCollection<ArticleDetailsModel>();

                var article = await this.data
                    .Set<Article>()
                    .Where(a => a.Id == request.Id)
                    .FirstOrDefaultAsync();

                var projectedArticle = await this.data
                    .Set<Article>()
                    .Where(a => a.Id == request.Id)
                    .MapCollection<ArticleDetailsModel>()
                    .FirstOrDefaultAsync(cancellationToken);

                return projectedArticle;
            }
        }
    }
}

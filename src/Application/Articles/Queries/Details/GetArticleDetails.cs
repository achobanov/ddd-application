using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.Application.Infrastructure.Handlers;
using Blog.Application.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Blog.Domain.Articles;

namespace Blog.Application.Articles.Queries
{
    public class GetArticleDetails : IRequest<ArticleDetailsModel>
    {
        public int Id { get; set; }

        public class GetArticleDetailsHandler : Handler<GetArticleDetails, ArticleDetailsModel>
        {
            private readonly IPersistenceContract data;
            private readonly IMapper mapper;

            public GetArticleDetailsHandler(IPersistenceContract data, IMapper mapper)
            {
                this.data = data;
                this.mapper = mapper;
            }

            public override async Task<ArticleDetailsModel> Handle(
                GetArticleDetails request,
                CancellationToken cancellationToken)
            {
                var article = await this.data
                    .Set<Article>()
                    .Where(a => a.Id == request.Id)
                    .ProjectTo<ArticleDetailsModel>(this.mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);

                if (article != null)
                {
                    article.Author = "some author"; // Will be fixed in https://github.com/achobanov/web-application/issues/11
                }

                return article;
            }
        }
    }
}

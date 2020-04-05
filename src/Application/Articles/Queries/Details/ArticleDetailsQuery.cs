namespace Blog.Application.Articles.Queries.Details
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Blog.Application.Common.Handlers;
    using Blog.Application.Contracts;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ArticleDetailsQuery : IRequest<ArticleDetailsModel>
    {
        public int Id { get; set; }

        public class ArticleDetailsQueryHandler : Handler<ArticleDetailsQuery, ArticleDetailsModel>
        {
            private readonly IBlogData data;
            private readonly IMapper mapper;

            public ArticleDetailsQueryHandler(IBlogData data, IMapper mapper)
            {
                this.data = data;
                this.mapper = mapper;
            }

            public override async Task<ArticleDetailsModel> Handle(
                ArticleDetailsQuery request, 
                CancellationToken cancellationToken)
            {
                var article = await this.data
                    .Articles
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

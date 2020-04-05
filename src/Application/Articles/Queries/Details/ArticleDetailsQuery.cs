namespace Blog.Application.Articles.Queries.Details
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Blog.Application.Common.Handlers;
    using Common.Interfaces;
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

            public override Task<ArticleDetailsModel> Handle(
                ArticleDetailsQuery request, 
                CancellationToken cancellationToken)
                => this.data
                    .Articles
                    .Where(a => a.Id == request.Id)
                    .ProjectTo<ArticleDetailsModel>(this.mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
        }
    }
}

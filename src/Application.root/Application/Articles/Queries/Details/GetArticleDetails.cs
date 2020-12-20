using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using EnduranceContestManager.Common.Mappings;
using EnduranceContestManager.Application.Interfaces;
using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Domain.Articles;

namespace EnduranceContestManager.Application.Articles.Queries
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
                => await this.data
                    .Set<Article>()
                    .Where(a => a.Id == request.Id)
                    .MapCollection<ArticleDetailsModel>()
                    .FirstOrDefaultAsync(cancellationToken);
        }
    }
}

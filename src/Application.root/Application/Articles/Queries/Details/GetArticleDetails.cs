using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Application.Interfaces.Blog.Articles;

namespace EnduranceContestManager.Application.Articles.Queries.Details
{
    public class GetArticleDetails : IRequest<ArticleDetailsModel>
    {
        public int Id { get; set; }

        public class GetArticleDetailsHandler : Handler<GetArticleDetails, ArticleDetailsModel>
        {
            private readonly IArticleQueries queries;

            public GetArticleDetailsHandler(IArticleQueries queries)
                => this.queries = queries;

            public override async Task<ArticleDetailsModel> Handle(
                GetArticleDetails request,
                CancellationToken cancellationToken)
                => await this.queries.Find<ArticleDetailsModel>(request.Id);
        }
    }
}

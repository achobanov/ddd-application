using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EnduranceContestManager.Application.Interfaces;
using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Core.Contracts;
using EnduranceContestManager.Domain.Articles;

namespace EnduranceContestManager.Application.Articles.Commands
{
    public class ChangeArticleVisibility : IRequest
    {
        public int Id { get; set; }

        public class ChangeArticleVisibilityHandler : Handler<ChangeArticleVisibility>
        {
            private readonly IPersistenceContract data;

            public ChangeArticleVisibilityHandler(
                IPersistenceContract data, 
                IDateTime dateTime)
            {
                this.data = data;
                this.DateTime = dateTime;
            }

            public IDateTime DateTime { get; }

            protected override async Task Handle(
                ChangeArticleVisibility request,
                CancellationToken cancellationToken)
            {
                var article = await this.data
                    .Set<Article>()
                    .Find(request.Id);

                if (article == null)
                {
                    return;
                }

                article.IsPublic = !article.IsPublic;

                if (article.PublishedOn == null)
                {
                    article.PublishedOn = this.DateTime.Now;
                }

                await this.data.SaveChanges(cancellationToken);
            }
        }
    }
}

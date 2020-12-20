using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EnduranceContestManager.Application.Interfaces;
using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Domain.Articles;

namespace EnduranceContestManager.Application.Articles.Commands
{
    public class CreateArticle : IRequest<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public class CreateArticleHandler : Handler<CreateArticle, int>
        {
            private readonly IPersistenceContract persistence;

            public CreateArticleHandler(IPersistenceContract data)
                => this.persistence = data;

            public override async Task<int> Handle(
                CreateArticle request,
                CancellationToken cancellationToken)
            {
                var article = new Article(request.Title, request.Content);

                await this.persistence
                    .Set<Article>()
                    .Add(article);

                await this.persistence.SaveChanges(cancellationToken);

                return article.Id;
            }
        }
    }
}

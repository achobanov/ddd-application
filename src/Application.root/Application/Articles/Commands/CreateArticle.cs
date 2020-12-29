using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Application.Interfaces.Blog.Articles;
using EnduranceContestManager.Domain.Articles;

namespace EnduranceContestManager.Application.Articles.Commands
{
    public class CreateArticle : IRequest<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public class CreateArticleHandler : Handler<CreateArticle, int>
        {
            private readonly IArticleCommands commands;

            public CreateArticleHandler(IArticleCommands commands)
                => this.commands = commands;

            public override async Task<int> Handle(
                CreateArticle request,
                CancellationToken cancellationToken)
            {
                var article = new Article(request.Title, request.Content);

                await this.commands.Save(article, cancellationToken);

                return article.Id;
            }
        }
    }
}

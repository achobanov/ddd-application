using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Infrastructure.Handlers;
using Blog.Application.Contracts;
using MediatR;
using Blog.Domain.Articles;

namespace Blog.Application.Articles.Commands
{
    public class CreateArticle : IRequest<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public class CreateArticleHandler : Handler<CreateArticle, int>
        {
            private readonly IPersistenceContract data;
            private readonly IAuthenticationContext authenticationContext;

            public CreateArticleHandler(
                IPersistenceContract data,
                IAuthenticationContext authenticationContext)
            {
                this.data = data;
                this.authenticationContext = authenticationContext;
            }

            public override async Task<int> Handle(
                CreateArticle request,
                CancellationToken cancellationToken)
            {
                var article = new Article(request.Title, request.Content, this.authenticationContext.Username);

                await this.data
                    .Set<Article>()
                    .Add(article);

                await this.data.SaveChanges(cancellationToken);

                return article.Id;
            }
        }
    }
}

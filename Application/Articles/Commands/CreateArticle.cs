using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Infrastructure.Handlers;
using Blog.Application.Contracts;
using MediatR;
using Blog.Domain.Articles;
using Blog.Domain.Authors;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Articles.Commands
{
    public class CreateArticle : IRequest<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public class CreateArticleHandler : Handler<CreateArticle, int>
        {
            private readonly IPersistenceContract persistence;
            private readonly IAuthenticationContext authenticationContext;

            public CreateArticleHandler(
                IPersistenceContract persistence,
                IAuthenticationContext authenticationContext)
            {
                this.persistence = persistence;
                this.authenticationContext = authenticationContext;
            }

            public override async Task<int> Handle(
                CreateArticle request,
                CancellationToken cancellationToken)
            {
                var author = await this.persistence
                    .Set<Author>()
                    .FirstOrDefaultAsync(a => a.Username == this.authenticationContext.Username);

                if (author == null)
                {
                    author = new Author(this.authenticationContext.Username);
                }

                var article = new Article(request.Title, request.Content, author);

                await this.persistence
                    .Set<Article>()
                    .Add(article);

                await this.persistence.SaveChanges(cancellationToken);

                return article.Id;
            }
        }
    }
}

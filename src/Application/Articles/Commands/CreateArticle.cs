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

using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Infrastructure.Handlers;
using Blog.Application.Contracts;
using MediatR;
using Blog.Common.Contracts;
using Blog.Domain.Entities;

namespace Blog.Application.Articles.Commands
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

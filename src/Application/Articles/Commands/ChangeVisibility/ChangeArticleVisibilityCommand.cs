namespace Blog.Application.Articles.Commands.ChangeVisibility
{
    using System.Threading;
    using System.Threading.Tasks;
    using Blog.Application.Infrastructure.Handlers;
    using Blog.Application.Contracts;
    using MediatR;
    using Blog.Common.Contracts;

    public class ChangeArticleVisibilityCommand : IRequest
    {
        public int Id { get; set; }

        public class ChangeArticleVisibilityCommandHandler : Handler<ChangeArticleVisibilityCommand>
        {
            private readonly IBlogData data;

            public ChangeArticleVisibilityCommandHandler(
                IBlogData data, 
                IDateTime dateTime)
            {
                this.data = data;
                this.DateTime = dateTime;
            }

            public IDateTime DateTime { get; }

            protected override async Task Handle(
                ChangeArticleVisibilityCommand request, 
                CancellationToken cancellationToken)
            {
                var article = await this.data.Articles.FindAsync(request.Id);

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

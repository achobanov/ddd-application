namespace Blog.Application.Articles.Commands.ChangeVisibility
{
    using System.Threading;
    using System.Threading.Tasks;
    using Blog.Application.Infrastructure.Handlers;
    using Blog.Application.Contracts;
    using MediatR;

    public class ChangeArticleVisibilityCommand : IRequest
    {
        public int Id { get; set; }

        public class ChangeArticleVisibilityCommandHandler : Handler<ChangeArticleVisibilityCommand>
        {
            private readonly IBlogData data;
            private readonly IDateTime dateTime;

            public ChangeArticleVisibilityCommandHandler(
                IBlogData data, 
                IDateTime dateTime)
            {
                this.data = data;
                this.dateTime = dateTime;
            }

            public IDateTime DateTime => dateTime;

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

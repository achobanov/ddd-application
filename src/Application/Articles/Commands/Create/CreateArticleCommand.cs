namespace Blog.Application.Articles.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Blog.Application.Infrastructure.Handlers;
    using Blog.Application.Contracts;
    using Domain.Entities;
    using MediatR;

    public class CreateArticleCommand : IRequest<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public class CreateArticleCommandHandler : Handler<CreateArticleCommand, int>
        {
            private readonly IBlogData data;
            private readonly IAuthenticationContract authenticationContext;

            public CreateArticleCommandHandler(
                IBlogData data,
                IAuthenticationContract authenticationContext)
            {
                this.data = data;
                this.authenticationContext = authenticationContext;
            }

            public override async Task<int> Handle(
                CreateArticleCommand request, 
                CancellationToken cancellationToken)
            {
                var article = new Article(request.Title, request.Content, this.authenticationContext.Username);

                this.data.Articles.Add(article);

                await this.data.SaveChanges(cancellationToken);

                return article.Id;
            }
        }
    }
}

namespace Blog.Application.Articles.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Blog.Application.Common.Handlers;
    using Common.Interfaces;
    using Domain.Entities;
    using MediatR;

    public class CreateArticleCommand : IRequest<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public class CreateArticleCommandHandler : Handler<CreateArticleCommand, int>
        {
            private readonly IBlogData data;
            private readonly ICurrentUser currentUser;

            public CreateArticleCommandHandler(
                IBlogData data,
                ICurrentUser currentUser)
            {
                this.data = data;
                this.currentUser = currentUser;
            }

            public override async Task<int> Handle(
                CreateArticleCommand request, 
                CancellationToken cancellationToken)
            {
                var article = new Article(request.Title, request.Content, this.currentUser.UserId);

                this.data.Articles.Add(article);

                await this.data.SaveChanges(cancellationToken);

                return article.Id;
            }
        }
    }
}

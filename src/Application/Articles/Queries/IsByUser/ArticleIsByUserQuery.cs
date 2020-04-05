namespace Blog.Application.Articles.Queries.IsByUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Blog.Application.Common.Handlers;
    using Blog.Application.Contracts;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ArticleIsByUserQuery : IRequest<bool>
    {
        public int Id { get; set; }

        public class ArticleIsByUserQueryHandler : Handler<ArticleIsByUserQuery, bool>
        {
            private readonly IBlogData data;
            private readonly IIdentityContext currentUser;

            public ArticleIsByUserQueryHandler(IBlogData data, IIdentityContext currentUser)
            {
                this.data = data;
                this.currentUser = currentUser;
            }

            public override async Task<bool> Handle(
                ArticleIsByUserQuery request, 
                CancellationToken cancellationToken) 
                => await this.data
                    .Articles
                    .AnyAsync(
                        a => a.Id == request.Id && a.CreatedBy == this.currentUser.UserId,
                        cancellationToken);
        }
    }
}

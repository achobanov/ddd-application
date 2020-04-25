namespace Blog.Application.Articles.Queries.IsByUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Blog.Application.Infrastructure.Handlers;
    using Blog.Application.Contracts;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Blog.Domain.Entities;

    public class ArticleIsByUserQuery : IRequest<bool>
    {
        public int Id { get; set; }

        public class ArticleIsByUserQueryHandler : Handler<ArticleIsByUserQuery, bool>
        {
            private readonly IPersistenceContract data;
            private readonly IAuthenticationContract authenticationContext;

            public ArticleIsByUserQueryHandler(IPersistenceContract data, IAuthenticationContract authenticationContext)
            {
                this.data = data;
                this.authenticationContext = authenticationContext;
            }

            public override async Task<bool> Handle(
                ArticleIsByUserQuery request, 
                CancellationToken cancellationToken) 
                => await this.data
                    .Set<Article>()
                    .AnyAsync(
                        a => a.Id == request.Id && a.CreatedBy == this.authenticationContext.Username,
                        cancellationToken);
        }
    }
}

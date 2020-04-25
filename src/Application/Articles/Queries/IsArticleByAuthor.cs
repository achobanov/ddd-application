using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Infrastructure.Handlers;
using Blog.Application.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Blog.Domain.Articles;

namespace Blog.Application.Articles.Queries.IsByUser
{
    public class IsArticleByAuthor : IRequest<bool>
    {
        public int Id { get; set; }

        public class IsArticleByAuthorHandler : Handler<IsArticleByAuthor, bool>
        {
            private readonly IPersistenceContract data;
            private readonly IAuthenticationContract authenticationContext;

            public IsArticleByAuthorHandler(IPersistenceContract data, IAuthenticationContract authenticationContext)
            {
                this.data = data;
                this.authenticationContext = authenticationContext;
            }

            public override async Task<bool> Handle(
                IsArticleByAuthor request,
                CancellationToken cancellationToken) 
                => await this.data
                    .Set<Article>()
                    .AnyAsync(
                        a => a.Id == request.Id && a.CreatedBy == this.authenticationContext.Username,
                        cancellationToken);
        }
    }
}

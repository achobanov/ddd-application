using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using EnduranceContestManager.Application.Contracts;
using EnduranceContestManager.Application.Infrastructure.Handlers;
using EnduranceContestManager.Domain.Articles;

namespace EnduranceContestManager.Application.Articles.Queries.IsByUser
{
    public class IsArticleByAuthor : IRequest<bool>
    {
        public int Id { get; set; }

        public class IsArticleByAuthorHandler : Handler<IsArticleByAuthor, bool>
        {
            private readonly IPersistenceContract data;
            private readonly IAuthenticationContext authenticationContext;

            public IsArticleByAuthorHandler(IPersistenceContract data, IAuthenticationContext authenticationContext)
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

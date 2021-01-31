using EnduranceContestManager.Application.Core.Requests;
using EnduranceContestManager.Application.Interfaces.Core;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Core.Handlers
{
    public class FindHandler<TEntity, TRequest, TResponse> : Handler<TRequest, TResponse>
        where TEntity : IAggregateRoot
        where TRequest : IIdentifiableRequest, IRequest<TResponse>
        where TResponse : IMapFrom<TEntity>
    {
        private readonly IQueryRepository<TEntity> query;

        public FindHandler(IQueryRepository<TEntity> query)
        {
            this.query = query;
        }

        public override Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = this.query.Find<TResponse>(request.Id);

            return entity;
        }
    }
}

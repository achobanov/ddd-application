using EnduranceContestManager.Application.Core.Interfaces;
using EnduranceContestManager.Application.Core.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Core.Handlers
{
    public class FindHandler<TRequest, TResponse> : Handler<TRequest, TResponse>
        where TRequest : IIdentifiableRequest, IRequest<TResponse>
    {
        private readonly IQueryRepository query;

        public FindHandler(IQueryRepository query)
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

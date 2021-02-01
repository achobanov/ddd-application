using EnduranceContestManager.Application.Core.Interfaces;
using EnduranceContestManager.Application.Core.Requests;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Gateways.Persistence.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceContestManager.Application.Core.Handlers
{
    public class FindHandler<TDataEntry, TRequest, TResponse> : Handler<TRequest, TResponse>
        where TDataEntry : DataEntry
        where TRequest : IIdentifiableRequest, IRequest<TResponse>
        where TResponse : IMapFrom<TDataEntry>
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

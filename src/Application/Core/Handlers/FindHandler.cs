using EnduranceJudge.Application.Core.Requests;
using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Domain.Core.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Core.Handlers
{
    public class FindHandler<TRequest, TResponse, TDomainModel> : Handler<TRequest, TResponse>
        where TRequest : IIdentifiableRequest, IRequest<TResponse>
        where TDomainModel : IAggregateRoot
    {
        private readonly IQueryRepository<TDomainModel> query;

        public FindHandler(IQueryRepository<TDomainModel> query)
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

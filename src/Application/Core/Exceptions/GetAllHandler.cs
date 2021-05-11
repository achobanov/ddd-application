using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Domain.Core.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Core.Exceptions
{
    public class GetAllHandler<TRequest, TResponse, TDomainModel> : Handler<TRequest, IEnumerable<TResponse>>
        where TRequest : IRequest<IEnumerable<TResponse>>
        where TDomainModel : IAggregateRoot
    {
        private readonly IQueriesBase<TDomainModel> queries;

        public GetAllHandler(IQueriesBase<TDomainModel> queries)
        {
            this.queries = queries;
        }

        public override async Task<IEnumerable<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var result = await this.queries.All<TResponse>();
            return result;
        }
    }
}

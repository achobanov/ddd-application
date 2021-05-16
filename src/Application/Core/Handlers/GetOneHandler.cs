using EnduranceJudge.Application.Core.Requests;
using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Domain.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Core.Handlers
{
    public class GetOneHandler<TRequest, TResponse, TDomainModel> : Handler<TRequest, TResponse>
        where TRequest : IIdentifiableRequest<TResponse>
        where TDomainModel : IDomainModel
    {
        private readonly IQueriesBase<TDomainModel> query;

        public GetOneHandler(IQueriesBase<TDomainModel> query)
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

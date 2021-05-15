using EnduranceJudge.Application.Contracts.Events;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Core.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Events.Queries.GetEvent
{
    public class GetEnduranceEvent : IIdentifiableRequest<EnduranceEventForUpdateModel>
    {
        public static GetEnduranceEvent New(int id)
            => new GetEnduranceEvent()
            {
                Id = id,
            };

        public int Id { get; set; }

        public class GetEnduranceEventHandler : Handler<GetEnduranceEvent, EnduranceEventForUpdateModel>
        {
            private readonly IEnduranceEventQueries enduranceEventQueries;

            public GetEnduranceEventHandler(IEnduranceEventQueries enduranceEventQueries)
            {
                this.enduranceEventQueries = enduranceEventQueries;
            }

            public override async Task<EnduranceEventForUpdateModel> Handle(
                GetEnduranceEvent request,
                CancellationToken cancellationToken)
            {
                var enduranceEvent = await this.enduranceEventQueries.Find<EnduranceEventForUpdateModel>(request.Id);
                return enduranceEvent;
            }
        }
    }
}

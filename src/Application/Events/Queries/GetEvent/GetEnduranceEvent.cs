using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Events.Queries.GetEvent
{
    public class GetEnduranceEvent : IRequest<EnduranceEventForUpdateModel>
    {
        public static GetEnduranceEvent New(int id)
            => new GetEnduranceEvent()
            {
                Id = id,
            };

        public int Id { get; set; }

        public class GetEventHandler : Handler<GetEnduranceEvent, EnduranceEventForUpdateModel>
        {
            private readonly IQueriesBase<EnduranceEvent> eventQueries;

            public GetEventHandler(IQueriesBase<EnduranceEvent> eventQueries)
            {
                this.eventQueries = eventQueries;
            }

            public override async Task<EnduranceEventForUpdateModel> Handle(
                GetEnduranceEvent request,
                CancellationToken cancellationToken)
            {
                var enduranceEvent = await this.eventQueries
                    .Find(request.Id)
                    .Map<EnduranceEventForUpdateModel>();

                return enduranceEvent;
            }
        }
    }
}

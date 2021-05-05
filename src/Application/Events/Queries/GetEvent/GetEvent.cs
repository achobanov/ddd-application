using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Domain.Aggregates.Event.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Events.Queries.GetEvent
{
    public class GetEvent : IRequest<EventForUpdateModel>
    {
        public static GetEvent New(int id)
            => new GetEvent()
            {
                Id = id,
            };

        public int Id { get; set; }

        public class GetEventHandler : Handler<GetEvent, EventForUpdateModel>
        {
            private readonly IQueriesBase<Event> eventQueries;

            public GetEventHandler(IQueriesBase<Event> eventQueries)
            {
                this.eventQueries = eventQueries;
            }

            public override async Task<EventForUpdateModel> Handle(
                GetEvent request,
                CancellationToken cancellationToken)
            {
                var _event = await this.eventQueries
                    .Find(request.Id)
                    .Map<EventForUpdateModel>();

                return _event;
            }
        }
    }
}

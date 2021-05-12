using EnduranceJudge.Application.Contracts.Events;
using EnduranceJudge.Application.Core.Handlers;
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
            private readonly IEventQueries eventQueries;

            public GetEventHandler(IEventQueries eventQueries)
            {
                this.eventQueries = eventQueries;
            }

            public override async Task<EnduranceEventForUpdateModel> Handle(
                GetEnduranceEvent request,
                CancellationToken cancellationToken)
            {
                var enduranceEvent = await this.eventQueries.Find<EnduranceEventForUpdateModel>(request.Id);
                return enduranceEvent;
            }
        }
    }
}

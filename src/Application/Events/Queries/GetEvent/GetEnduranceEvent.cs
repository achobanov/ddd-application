using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Core.Requests;
using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;

namespace EnduranceJudge.Application.Events.Queries.GetEvent
{
    public class GetEnduranceEvent : IdentifiableRequest<EnduranceEventForUpdateModel>
    {
        public class GetEnduranceEventHandler
            : GetOneHandler<GetEnduranceEvent, EnduranceEventForUpdateModel, EnduranceEvent>
        {
            public GetEnduranceEventHandler(IQueriesBase<EnduranceEvent> query) : base(query)
            {
            }
        }
    }
}

using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Application.Core.Exceptions;
using EnduranceJudge.Application.Events.Common;
using EnduranceJudge.Domain.Aggregates.Event.EnduranceEvents;
using MediatR;
using System.Collections.Generic;

namespace EnduranceJudge.Application.Events.Queries.GetEventsList
{
    public class GetEventsList : IRequest<IEnumerable<ListModel>>
    {
        public class GetEventsListHandler : GetAllHandler<GetEventsList, ListModel, EnduranceEvent>
        {
            public GetEventsListHandler(IQueriesBase<EnduranceEvent> queries) : base(queries)
            {
            }
        }
    }
}

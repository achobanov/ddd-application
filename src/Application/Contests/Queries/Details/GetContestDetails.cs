using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Core.Requests;
using EnduranceJudge.Application.Contracts.Events;
using EnduranceJudge.Domain.Aggregates.Event.Events;
using MediatR;

namespace EnduranceJudge.Application.Contests.Queries.Details
{
    public class GetContestDetails : IRequest<ContestDetailsModel>, IIdentifiableRequest
    {
        public int Id { get; set; }

        public class GetContestDetailsHandler : FindHandler<GetContestDetails, ContestDetailsModel, Event>
        {
            public GetContestDetailsHandler(IEventQueries queries)
                : base(queries)
            {
            }
        }
    }
}

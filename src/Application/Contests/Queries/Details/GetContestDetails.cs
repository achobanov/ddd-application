using EnduranceJudge.Application.Core.Handlers;
using EnduranceJudge.Application.Core.Requests;
using EnduranceJudge.Application.Interfaces.Events;
using MediatR;

namespace EnduranceJudge.Application.Contests.Queries.Details
{
    public class GetContestDetails : IRequest<ContestDetailsModel>, IIdentifiableRequest
    {
        public int Id { get; set; }

        public class GetContestDetailsHandler : FindHandler<GetContestDetails, ContestDetailsModel>
        {
            public GetContestDetailsHandler(IEventQueries queries)
                : base(queries)
            {
            }
        }
    }
}

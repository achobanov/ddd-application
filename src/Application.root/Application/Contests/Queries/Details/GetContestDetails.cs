using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Application.Core.Requests;
using EnduranceContestManager.Application.Interfaces.Contests;
using EnduranceContestManager.Domain.Entities.Contests;
using MediatR;

namespace EnduranceContestManager.Application.Contests.Queries.Details
{
    public class GetContestDetails : IRequest<ContestDetailsModel>, IIdentifiableRequest
    {
        public int Id { get; set; }

        public class GetContestDetailsHandler : FindHandler<Contest, GetContestDetails, ContestDetailsModel>
        {
            public GetContestDetailsHandler(IContestQueries queries)
                : base(queries)
            {
            }
        }
    }
}

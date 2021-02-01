using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Gateways.Persistence.Data.Contests;

namespace EnduranceContestManager.Application.Contests.Queries
{
    public class ContestDetailsModel : IMapFrom<ContestData>
    {
        public string Name { get; set; }

        public string Country { get; set; }
    }
}

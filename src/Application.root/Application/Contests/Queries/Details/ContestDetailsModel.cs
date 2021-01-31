using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Contests;

namespace EnduranceContestManager.Application.Contests.Queries
{
    public class ContestDetailsModel : IMapFrom<Contest>
    {
        public string Name { get; set; }

        public string Country { get; set; }
    }
}

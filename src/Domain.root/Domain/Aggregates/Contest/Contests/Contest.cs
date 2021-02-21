using EnduranceContestManager.Domain.Aggregates.Common;
using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Contests
{
    public partial class Contest : BaseContest<ContestException>, IAggregateRoot
    {
        public Contest(int id, string name, string country, string populatedPlace)
            : base(id, name, country, populatedPlace)
        {
        }
    }
}

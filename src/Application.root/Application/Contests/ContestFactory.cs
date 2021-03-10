using EnduranceContestManager.Application.Core.Factories;
using EnduranceContestManager.Domain.Aggregates.Common;
using EnduranceContestManager.Domain.Aggregates.Event.Contests;

namespace EnduranceContestManager.Application.Contests
{
    public class ContestFactory : Factory<Contest, IContestState>, IContestFactory
    {
        public Contest Update(Contest contest, string name = null, string populatedPlace = null)
            => new Contest(
                contest.Id,
                name ?? contest.Name,
                populatedPlace ?? contest.PopulatedPlace);

        protected override Contest FromState(IContestState state)
            => new Contest(default, state.Name, state.PopulatedPlace);
    }
}

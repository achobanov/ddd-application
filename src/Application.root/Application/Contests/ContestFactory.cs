using EnduranceContestManager.Application.Core.Factories;
using EnduranceContestManager.Domain.Aggregates.Contest.Contests;

namespace EnduranceContestManager.Application.Contests
{
    public class ContestFactory : Factory<Contest, IContestState>, IContestFactory
    {
        public Contest Update(Contest contest, string name = null, string populatedPlace = null, string country = null)
            => new Contest(
                contest.Id,
                name ?? contest.Name,
                populatedPlace ?? contest.PopulatedPlace,
                country ?? contest.Country);

        protected override Contest FromState(IContestState state)
            => new Contest(default, state.Name, state.PopulatedPlace, state.Country);
    }
}

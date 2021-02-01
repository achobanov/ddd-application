using EnduranceContestManager.Application.Core.Factories;
using EnduranceContestManager.Domain.Entities.Contests;

namespace EnduranceContestManager.Application.Contests
{
    public class ContestFactory : Factory<Contest, IContestState>, IContestFactory
    {
        protected override Contest FromState(IContestState state)
            => new Contest(
                default,
                state.Name,
                state.PopulatedPlace,
                state.Country,
                state.PresidentGroundJury,
                state.FeiTechDelegate,
                state.FeiVetDelegate,
                state.PresidentVetCommission,
                state.ForeignJudge,
                state.ActiveVet);
    }
}

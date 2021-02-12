using EnduranceContestManager.Application.Core.Factories;
using EnduranceContestManager.Domain.Entities.Contests;

namespace EnduranceContestManager.Application.Contests
{
    public class ContestFactory : Factory<Contest, IContestState>, IContestFactory
    {
        public Contest Update(
            Contest contest,
            string name = null,
            string populatedPlace = null,
            string country = null,
            string presidentGroundJury = null,
            string feiTechDelegate = null,
            string feiVetDelegate = null,
            string presidentVetCommission = null,
            string foreignJudge = null,
            string activeVet = null)
            => new Contest(
                contest.Id,
                name ?? contest.Name,
                populatedPlace ?? contest.PopulatedPlace,
                country ?? contest.Country,
                presidentGroundJury ?? contest.PresidentGroundJury,
                feiTechDelegate ?? contest.FeiTechDelegate,
                feiVetDelegate ?? contest.FeiVetDelegate,
                presidentVetCommission ?? contest.PresidentVetCommission,
                foreignJudge ?? contest.ForeignJudge,
                activeVet ?? contest.ActiveVet);

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

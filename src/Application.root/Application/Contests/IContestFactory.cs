using EnduranceContestManager.Application.Core.Factories;
using EnduranceContestManager.Domain.Entities.Contests;

namespace EnduranceContestManager.Application.Contests
{
    public interface IContestFactory : IFactory<Contest>
    {
        Contest Update(
            Contest contest,
            string name = null,
            string populatedPlace = null,
            string country = null,
            string presidentGroundJury = null,
            string feiTechDelegate = null,
            string feiVetDelegate = null,
            string presidentVetCommission = null,
            string foreignJudge = null,
            string activeVet = null);
    }
}

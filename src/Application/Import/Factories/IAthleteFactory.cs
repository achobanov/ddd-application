using EnduranceJudge.Application.Import.ImportFromFile.Models;
using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Domain.Aggregates.Import.Athletes;

namespace EnduranceJudge.Application.Import.Factories
{
    public interface IAthleteFactory : IService
    {
        Athlete Create(HorseSportShowEntriesAthlete data);
    }
}

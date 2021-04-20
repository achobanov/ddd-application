using EnduranceJudge.Application.Import.ImportFromFile.Xml;
using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Domain.Aggregates.Import.Athletes;
using System;

namespace EnduranceJudge.Application.Import.Factories
{
    public interface IAthleteFactory : IService
    {
        Athlete Create(HorseSportShowEntriesAthlete data);
    }
}

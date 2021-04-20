using EnduranceJudge.Application.Import.ImportFromFile.Xml;
using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Domain.Aggregates.Import.Horses;
using System;

namespace EnduranceJudge.Application.Import.Factories
{
    public interface IHorseFactory : IService
    {
        Horse Create(HorseSportShowEntriesHorse horse);
    }
}

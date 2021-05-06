using EnduranceJudge.Application.Import.ImportFromFile.Models;
using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Domain.Aggregates.Import.Horses;

namespace EnduranceJudge.Application.Import.Factories
{
    public interface IHorseFactory : IService
    {
        Horse Create(HorseSportShowEntriesHorse horse);

        Horse Create(HorseForNationalImportModel horse);
    }
}

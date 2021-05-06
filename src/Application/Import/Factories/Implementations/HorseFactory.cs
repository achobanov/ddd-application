using EnduranceJudge.Application.Import.ImportFromFile.Models;
using EnduranceJudge.Domain.Aggregates.Import.Horses;

namespace EnduranceJudge.Application.Import.Factories.Implementations
{
    public class HorseFactory : IHorseFactory
    {
        public Horse Create(HorseSportShowEntriesHorse data)
        {
            var hasParsed = bool.TryParse(data.Stallion, out var isStallion);
            if (!hasParsed)
            {
                return null;
            }

            var horse = new Horse(
                data.FEIID,
                name: data.Name,
                isStallion: isStallion,
                breed: data.StudBook,
                trainerFeiId: data.TrainerFEIID,
                trainerFirstName: data.TrainerFirstName,
                trainerLastName: data.TrainerFamilyName);

            return horse;
        }

        public Horse Create(HorseForNationalImportModel data)
        {
            var horse = new Horse(data.FeiId, name: data.Name, breed: data.Breed);
            return horse;
        }
    }
}

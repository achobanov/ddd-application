using EnduranceJudge.Application.Import.ImportFromFile.Xml;
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
                data.Name,
                isStallion,
                data.StudBook,
                data.TrainerFEIID,
                data.TrainerFirstName,
                data.TrainerFamilyName);

            return horse;
        }
    }
}

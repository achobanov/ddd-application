using EnduranceJudge.Application.Import.ImportFromFile.Xml;
using EnduranceJudge.Domain.Aggregates.Import.Athletes;
using System;
using System.Globalization;

namespace EnduranceJudge.Application.Import.Factories.Implementations
{
    public class AthleteFactory : IAthleteFactory
    {
        public Athlete Create(HorseSportShowEntriesAthlete data)
        {
            var hasParsed = DateTime.TryParseExact(
                data.BirthDate,
                "yyyy-mm-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var birthDate);

            if (!hasParsed)
            {
                return null;
            }

            var athlete = new Athlete(data.FEIID, data.FirstName, data.FamilyName, data.CompetingFor, birthDate);
            return athlete;
        }
    }
}

using EnduranceJudge.Domain.Aggregates.Common.Athletes;
using EnduranceJudge.Domain.States;

namespace EnduranceJudge.Application.Events.Factories.Implementations
{
    public class AthleteFactory : IAthleteFactory
    {
        public Athlete Create(IAthleteState data)
        {
            var athlete = new Athlete(
                data.Id,
                data.FeiId,
                data.FirstName,
                data.LastName,
                data.CountryIsoCode,
                data.Category);
            return athlete;
        }
    }
}

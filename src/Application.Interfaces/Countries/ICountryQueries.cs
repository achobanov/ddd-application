using EnduranceJudge.Application.Interfaces.Core;
using EnduranceJudge.Domain.Aggregates.Common.Countries;

namespace EnduranceJudge.Application.Interfaces.Countries
{
    public interface ICountryQueries : IQueryRepository<Country>
    {
    }
}

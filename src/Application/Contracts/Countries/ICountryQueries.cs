using EnduranceJudge.Application.Core.Contracts;
using EnduranceJudge.Domain.Aggregates.Common.Countries;

namespace EnduranceJudge.Application.Contracts.Countries
{
    public interface ICountryQueries : IQueryRepository<Country>
    {
    }
}

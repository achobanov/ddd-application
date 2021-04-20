using EnduranceJudge.Domain.Aggregates.Common.Countries;
using System.Threading.Tasks;

namespace EnduranceJudge.Application.Contracts.Countries
{
    public interface ICountryQueries
    {
        Task<Country> Find(string isoCode);
    }
}

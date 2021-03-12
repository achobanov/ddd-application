using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Common.Countries
{
    public interface ICountryState : IDomainModelState
    {
        string IsoCode { get; }

        string Name { get; }
    }
}

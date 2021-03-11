using EnduranceContestManager.Domain.Aggregates.Common.Countries;
using EnduranceContestManager.Domain.Core.Exceptions;
using EnduranceContestManager.Domain.Core.Models;
using EnduranceContestManager.Domain.Core.Validation;

namespace EnduranceContestManager.Domain.Aggregates.Common
{
    public abstract class BaseEvent<TException> : DomainModel<TException>, IEventState
        where TException : DomainException, new()
    {
        protected BaseEvent(int id, string name, string populatedPlace) : base(id)
            => this.Validate(() =>
            {
                this.Name = name.IsRequired(nameof(name));
                this.PopulatedPlace = populatedPlace.IsRequired(nameof(populatedPlace));
            });

        public string Name { get; protected set; }
        public string PopulatedPlace { get; protected set; }

        public Country Country { get; protected set; }

        public void Set(Country country)
            => this.Validate(() =>
            {
                this.Country = country.IsRequired(nameof(country));
            });
    }
}

using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Aggregates.Common
{
    public abstract class BaseContest<TException> : DomainModel<TException>, IContestState
        where TException : DomainException, new()
    {
        protected BaseContest(int id, string name, string country, string populatedPlace) : base(id)
            => this.Except(() =>
            {
                this.Name = name;
                this.Country = country;
                this.PopulatedPlace = populatedPlace;
            });

        public string Name { get; protected set; }
        public string Country { get; protected set; }
        public string PopulatedPlace { get; protected set; }
    }
}

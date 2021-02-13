namespace EnduranceContestManager.Domain.Core.Entities
{
    public abstract class DomainModel : IDomainModel
    {
        protected DomainModel(int? id)
        {
            this.Id = id ?? default;
        }

        public int Id { get; private set; }

        // Add GetHashCode(), Equals(), etc.
    }
}

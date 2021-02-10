namespace EnduranceContestManager.Domain.Core.Entities
{
    public abstract class Entity : IEntity
    {
        protected Entity(int? id)
        {
            this.Id = id ?? default;
        }

        public int Id { get; private set; }

        // Add GetHashCode(), Equals(), etc.
    }
}

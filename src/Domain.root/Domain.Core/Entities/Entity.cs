namespace EnduranceContestManager.Domain.Core.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }

        // Add GetHashCode(), Equals(), etc.
    }
}

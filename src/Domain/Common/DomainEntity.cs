namespace Blog.Domain.Common
{
    public abstract class DomainEntity
    {
        public virtual int Id { get; set; }

        // Add GetHashCode(), Equals(), etc.
    }
}

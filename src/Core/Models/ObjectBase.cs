using Newtonsoft.Json;
using System;

namespace EnduranceJudge.Core.Models
{
    public abstract class ObjectBase : IObject
    {
        protected ObjectBase()
        {
            this.ObjectId = Guid.NewGuid();
        }

        [JsonIgnore]
        public Guid ObjectId { get; }

        public virtual bool Equals(IObject? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other.GetType() != this.GetType())
            {
                return false;
            }

            return this.ObjectId.Equals(other.ObjectId);
        }

        public override bool Equals(object? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((ObjectBase) other);
        }

        public override int GetHashCode()
            => (this.GetType().ToString() + this.ObjectId).GetHashCode();
    }
}

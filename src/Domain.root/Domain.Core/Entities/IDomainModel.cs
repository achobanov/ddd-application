using System;

namespace EnduranceContestManager.Domain.Core.Entities
{
    public interface IDomainModel : IEquatable<IDomainModel>
    {
        public int Id { get; }
    }
}

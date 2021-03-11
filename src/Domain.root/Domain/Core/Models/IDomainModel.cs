using System;

namespace EnduranceContestManager.Domain.Core.Models
{
    public interface IDomainModel : IEquatable<IDomainModel>
    {
        public int Id { get; }
    }
}

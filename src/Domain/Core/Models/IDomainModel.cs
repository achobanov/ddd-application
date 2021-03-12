using System;

namespace EnduranceJudge.Domain.Core.Models
{
    public interface IDomainModel : IEquatable<IDomainModel>
    {
        public int Id { get; }
    }
}

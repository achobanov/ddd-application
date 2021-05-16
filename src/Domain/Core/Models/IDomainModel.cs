using EnduranceJudge.Core.Models;
using System;

namespace EnduranceJudge.Domain.Core.Models
{
    public interface IDomainModel : IEquatable<IDomainModel>, IIdentifiable
    {
    }
}

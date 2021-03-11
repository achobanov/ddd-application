using EnduranceContestManager.Domain.Core.Models;

namespace EnduranceContestManager.Domain.Core.Models
{
    internal interface IDependsOn<in TPrincipal> : IDomainModel
        where TPrincipal : IDomainModel
    {
        void Set(TPrincipal domainModel);

        void Clear(TPrincipal domainModel);
    }
}

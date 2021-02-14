using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain
{
    internal interface IDependsOn<in TPrincipal> : IDomainModel
        where TPrincipal : IDomainModel
    {
        void Set(TPrincipal domainModel);

        void Clear(TPrincipal domainModel);
    }
}

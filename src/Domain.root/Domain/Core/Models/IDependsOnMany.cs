namespace EnduranceContestManager.Domain.Core.Models
{
    internal interface IDependsOnMany<in TDomainModel>
        where TDomainModel : IInternalDomainModel
    {
        void AddOne(TDomainModel child);

        void RemoveOne(TDomainModel child);
    }
}

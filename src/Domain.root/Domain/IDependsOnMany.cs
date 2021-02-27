namespace EnduranceContestManager.Domain
{
    internal interface IDependsOnMany<in TDomainModel>
        where TDomainModel : IInternalDomainModel
    {
        void AddOne(TDomainModel child);

        void RemoveOne(TDomainModel child);
    }
}

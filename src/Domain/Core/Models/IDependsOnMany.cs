namespace EnduranceJudge.Domain.Core.Models
{
    internal interface IDependsOnMany<in TDomainModel> : IDomainModel
        where TDomainModel : IInternalDomainModel
    {
        void AddOne(TDomainModel child);

        void RemoveOne(TDomainModel child);
    }
}

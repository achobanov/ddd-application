using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Application.Events.Factories
{
    public interface IPersonnelFactory : IService
    {
        Personnel Create(string name, PersonnelRole role);
    }
}

using EnduranceJudge.Core.ConventionalServices;
using EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel;

namespace EnduranceJudge.Application.Events.Factories
{
    public interface IPersonnelFactory : IService
    {
        Personnel PresidentGroundJury(string name);
        Personnel PresidentVetCommission(string name);
        Personnel FeiTechDelegate(string name);
        Personnel FeiVetDelegate(string name);
        Personnel ForeignJudge(string name);
        Personnel ActiveVet(string name);
        Personnel MemberOfVetCommittee(string name);
        Personnel MemberOfJudgeCommittee(string name);
        Personnel Steward(string name);
    }
}

using EnduranceJudge.Domain.Aggregates.Event.Personnels;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Application.Events.Factories.Implementations
{
    public class PersonnelFactory : IPersonnelFactory
    {
        public Personnel PresidentGroundJury(string name)
        {
            var personnel = this.Create(name, PersonnelRole.PresidentGroundJury);
            return personnel;
        }

        public Personnel PresidentVetCommission(string name)
        {
            var personnel = this.Create(name, PersonnelRole.PresidentVetCommission);
            return personnel;
        }

        public Personnel FeiTechDelegate(string name)
        {
            var personnel = this.Create(name, PersonnelRole.FeiTechDelegate);
            return personnel;
        }

        public Personnel FeiVetDelegate(string name)
        {
            var personnel = this.Create(name, PersonnelRole.FeiVetDelegate);
            return personnel;
        }

        public Personnel ForeignJudge(string name)
        {
            var personnel = this.Create(name, PersonnelRole.ForeignJudge);
            return personnel;
        }

        public Personnel ActiveVet(string name)
        {
            var personnel = this.Create(name, PersonnelRole.ActiveVet);
            return personnel;
        }

        public Personnel MemberOfVetCommittee(string name)
        {
            var personnel = this.Create(name, PersonnelRole.MemberOfVetCommittee);
            return personnel;
        }

        public Personnel MemberOfJudgeCommittee(string name)
        {
            var personnel = this.Create(name, PersonnelRole.MemberOfJudgeCommittee);
            return personnel;
        }

        public Personnel Steward(string name)
        {
            var personnel = this.Create(name, PersonnelRole.Steward);
            return personnel;
        }

        private Personnel Create(string name, PersonnelRole role)
            => new Personnel(default, name, role);
    }
}

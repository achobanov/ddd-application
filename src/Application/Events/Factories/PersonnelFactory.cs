using EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Application.Events.Factories
{
    public class PersonnelFactory : IPersonnelFactory
    {
        public Personnel Create(string name, PersonnelRole role)
        {
            var personnel = new Personnel(name, role);
            return personnel;
        }
    }
}

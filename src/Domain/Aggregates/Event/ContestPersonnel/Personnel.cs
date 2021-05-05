using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Validation;
using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Enums;

namespace EnduranceJudge.Domain.Aggregates.Event.ContestPersonnel
{
    public class Personnel : DomainModel<PersonnelException>, IPersonnelState,
        IDependsOn<Events.Event>
    {
        public Personnel() : base(default)
        {
        }

        public Personnel(string name, PersonnelRole role) : base(default)
            => this.Validate(() =>
            {
                this.Name = name.CheckPersonName();
                this.Role = role.IsNotDefault(nameof(role));
            });

        public string Name { get; private set; }
        public PersonnelRole Role { get; private set; }

        public Events.Event Event { get; private set; }
        void IDependsOn<Events.Event>.Set(Events.Event domainModel)
            => this.Validate(() =>
            {
                this.Event.IsNotRelated();
                this.Event = domainModel;
            });
        void IDependsOn<Events.Event>.Clear(Events.Event domainModel)
        {
            this.Event = null;
        }
    }
}

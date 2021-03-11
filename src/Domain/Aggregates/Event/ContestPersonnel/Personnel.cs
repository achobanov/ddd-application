using EnduranceContestManager.Domain.Core.Models;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Validation;

namespace EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel
{
    public class Personnel : DomainModel<PersonnelException>, IPersonnelState,
        IDependsOn<Events.Event>
    {
        public Personnel(int id, string name)
            : base(id)
            => this.Validate(() =>
            {
                this.Name = name.CheckPersonName();
            });

        public string Name { get; private set; }

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

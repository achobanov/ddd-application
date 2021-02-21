using EnduranceContestManager.Domain.Core.Validation;

namespace EnduranceContestManager.Domain.Aggregates.Manager.Participations
{
    public class Participant : DomainModel<ManagerParticipationException>,
        IDependsOn<Participation>
    {
        public Participant(int id) : base(id)
        {
        }

        public Participation Participation { get; private set; }
        void IDependsOn<Participation>.Set(Participation domainModel)
            => this.Except(() =>
            {
                this.Participation.CheckNotRelated();
                this.Participation = domainModel;
            });
        void IDependsOn<Participation>.Clear(Participation domainModel)
        {
            this.Participation = null;
        }
    }
}

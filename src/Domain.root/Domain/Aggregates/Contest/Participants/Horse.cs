using EnduranceContestManager.Domain.Core.Validation;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Participants
{
    public class Horse : DomainModel<ParticipantException>,
        IDependsOn<Participant>
    {
        public Horse(int id) : base(id)
        {
        }

        public Participant Participant { get; private set; }
        void IDependsOn<Participant>.Set(Participant domainModel)
        {
            this.Participant.IsNotRelated();
            this.Participant = domainModel;
        }
        void IDependsOn<Participant>.Clear(Participant domainModel)
        {
            this.Participant = null;
        }
    }
}

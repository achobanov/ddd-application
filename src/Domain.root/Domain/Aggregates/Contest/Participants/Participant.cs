using EnduranceContestManager.Domain.Aggregates.Contest.Trials;
using EnduranceContestManager.Domain.Core.Validation;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Participants
{
    public class Participant : DomainModel<ParticipantException>, IParticipantState,
        IDependsOn<Trial>
    {
        public Participant(int id, string rfId, int contestNumber) : base(id)
        {
            this.Except(() =>
            {
                this.RfId = rfId.IsRequired(nameof(rfId));
                this.ContestNumber = contestNumber.IsRequired(nameof(contestNumber));
            });
        }

        public string RfId { get; private set; }
        public int ContestNumber { get; private set; }

        public Horse Horse { get; private set; }
        public Participant Set(Horse horse)
        {
            this.Set(
                participant => participant.Horse,
                (participant, h) => participant.Horse = h,
                horse);

            return this;
        }

        public Rider Rider { get; private set; }
        public Participant Set(Rider rider)
        {
            this.Set(
                participant => participant.Rider,
                (participant, r) => participant.Rider = r,
                rider);

            return this;
        }

        public Trial Trial { get; private set; }
        void IDependsOn<Trial>.Set(Trial domainModel)
            => this.Except(() =>
            {
                this.Trial.CheckNotRelated();
                this.Trial = domainModel;
            });
        void IDependsOn<Trial>.Clear(Trial domainModel)
        {
            this.Trial = null;
        }
    }
}

using EnduranceContestManager.Domain.Aggregates.Event.Competitions;
using EnduranceContestManager.Domain.Core.Validation;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Event.Participants
{
    public class Participant : DomainModel<ParticipantException>, IParticipantState,
        IDependsOnMany<Competition>
    {
        public Participant(int id, string rfId, int contestNumber) : base(id)
        {
            this.Validate(() =>
            {
                this.RfId = rfId.IsRequired(nameof(rfId));
                this.ContestNumber = contestNumber.IsRequired(nameof(contestNumber));
            });
        }

        public string RfId { get; private set; }
        public int ContestNumber { get; private set; }
        public int? MaxAverageSpeedInKpH { get; private set; }

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

        private readonly List<Competition> competitions = new();
        public IReadOnlyList<Competition> Competitions => this.competitions.AsReadOnly();
        void IDependsOnMany<Competition>.AddOne(Competition principal)
            => this.Validate(() =>
            {
                this.competitions.ValidateAndAdd(principal);
            });

        void IDependsOnMany<Competition>.RemoveOne(Competition principal)
            => this.Validate(() =>
            {
                this.competitions.ValidateAndRemove(principal);
            });
    }
}

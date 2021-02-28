using EnduranceContestManager.Domain.Aggregates.Contest.Trials;
using EnduranceContestManager.Domain.Core.Validation;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Participants
{
    public class Participant : DomainModel<ParticipantException>, IParticipantState,
        IDependsOnMany<Trial>
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

        private readonly List<Trial> trials = new();
        public IReadOnlyList<Trial> Trials => this.trials.AsReadOnly();
        void IDependsOnMany<Trial>.AddOne(Trial principal)
            => this.Validate(() =>
            {
                this.trials.ValidateAndAdd(principal);
            });

        void IDependsOnMany<Trial>.RemoveOne(Trial principal)
            => this.Validate(() =>
            {
                this.trials.ValidateAndRemove(principal);
            });
    }
}

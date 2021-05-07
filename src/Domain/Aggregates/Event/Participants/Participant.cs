using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Event.Participants
{
    public class Participant : DomainModel<ParticipantException>, IParticipantState
    {
        private Participant()
        {
        }

        public Participant(string rfId, int contestNumber)
            => this.Validate(() =>
            {
                this.RfId = rfId.IsRequired(nameof(rfId));
                this.ContestNumber = contestNumber.IsRequired(nameof(contestNumber));
            });

        public string RfId { get; private set; }
        public int ContestNumber { get; private set; }
        public int? MaxAverageSpeedInKpH { get; private set; }

        public Horse Horse { get; private set; }
        public Participant Set(Horse horse)
        {
            this.Horse = horse; // TODO: Validate similarly to .ValidateAndAdd?
            return this;
        }

        public Athlete Athlete { get; private set; }
        public Participant Set(Athlete athlete)
        {
            this.Athlete = athlete; //TODO: Validate
            return this;
        }
    }
}

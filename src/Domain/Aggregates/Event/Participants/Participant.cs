using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Event.Participants
{
    public class Participant : DomainBase<ParticipantException>, IParticipantState
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
            this.Validate(
                () => horse.IsRequired(nameof(horse)));

            this.Horse = horse;
            return this;
        }

        public Athlete Athlete { get; private set; }
        public Participant Set(Athlete athlete)
        {
            this.Validate(
                () => athlete.IsRequired(nameof(athlete)));

            this.Athlete = athlete;
            return this;
        }
    }
}

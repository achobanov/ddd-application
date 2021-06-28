using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Core.Models;

namespace EnduranceJudge.Domain.Aggregates.Event.Participants
{
    public class Participant : DomainBase<ParticipantException>, IParticipantState
    {
        private Participant() : base(default)
        {
        }

        public Participant(IParticipantState data) : base(data.Id)
            => this.Validate(() =>
            {
                this.RfId = data.RfId.IsRequired(nameof(data.RfId));
                this.Number = data.Number.IsRequired(nameof(data.Number));
                this.MaxAverageSpeedInKmPh = data.MaxAverageSpeedInKmPh;
            });

        public string RfId { get; private set; }
        public int Number { get; private set; }
        public int? MaxAverageSpeedInKmPh { get; private set; }

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

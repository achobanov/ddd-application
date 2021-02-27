
using EnduranceContestManager.Domain.Aggregates.Import.Horses;
using EnduranceContestManager.Domain.Aggregates.Import.Riders;
using EnduranceContestManager.Domain.Core.Validation;

namespace EnduranceContestManager.Domain.Aggregates.Import.Participants
{
    public class Participant : DomainModel<ImportParticipantException>
    {
        public Participant(Rider rider, Horse horse) : base(default)
            => this.Validate(() =>
            {
                this.Rider = rider.IsRequired(nameof(rider));
                this.Horse = horse.IsRequired(nameof(horse));
            });

        public Rider Rider { get; private set; }
        public Horse Horse { get; private set; }
    }
}

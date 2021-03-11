using EnduranceContestManager.Domain.Aggregates.Import.Horses;
using EnduranceContestManager.Domain.Aggregates.Import.Athletes;
using EnduranceContestManager.Domain.Core.Models;
using EnduranceContestManager.Domain.Core.Validation;

namespace EnduranceContestManager.Domain.Aggregates.Import.Participants
{
    public class Participant : DomainModel<ImportParticipantException>
    {
        public Participant(Athlete athlete, Horse horse) : base(default)
            => this.Validate(() =>
            {
                this.Athlete = athlete.IsRequired(nameof(athlete));
                this.Horse = horse.IsRequired(nameof(horse));
            });

        public Athlete Athlete { get; private set; }
        public Horse Horse { get; private set; }
    }
}

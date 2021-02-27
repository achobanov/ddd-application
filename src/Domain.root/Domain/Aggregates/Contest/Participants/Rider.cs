using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Enums;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Participants
{
    public class Rider : DomainModel<ParticipantException>,
        IDependsOn<Participant>
    {
        public Rider(int id, Category category) : base(id)
            => this.Validate(() =>
            {
                this.Category = category.IsRequired(nameof(category));
            });

        public Category Category { get; private set; }

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

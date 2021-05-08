using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Aggregates.Event.Participants;
using EnduranceJudge.Domain.Aggregates.Event.Phases;
using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Event.Competitions
{
    public class Competition : DomainModel<CompetitionException>, ICompetitionState
    {
        private Competition()
        {
        }

        public Competition(CompetitionType type)
            => this.Validate(() =>
            {
                this.Type = type.IsRequired(nameof(type));
            });

        public CompetitionType Type { get; private set; }

        private List<Phase> phases = new();
        public IReadOnlyList<Phase> Phases
        {
            get => this.phases.AsReadOnly();
            private set => this.phases = value.ToList();
        }
        public Competition Add(Phase phase)
        {
            this.phases.ValidateAndAdd(phase);
            return this;
        }

        private List<Participant> participants = new();
        public IReadOnlyList<Participant> Participants
        {
            get => this.participants.AsReadOnly();
            private set => this.participants = value.ToList();
        }
        public Competition Add(Participant participant)
        {
            this.participants.ValidateAndAdd(participant);
            return this;
        }
        public Competition Remove(Participant participant)
        {
            this.participants.ValidateAndRemove(participant);
            return this;
        }
    }
}

using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Core.Extensions;
using EnduranceJudge.Domain.Aggregates.Event.Participants;
using EnduranceJudge.Domain.Aggregates.Event.Phases;
using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Event.Competitions
{
    public class Competition : DomainModel<CompetitionException>, ICompetitionState,
        IDependsOn<Events.Event>
    {
        public Competition(int id, CompetitionType type) : base(id)
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
            this.AddRelation(competition => competition.phases, phase);
            return this;
        }

        private List<Participant> participants = new();
        public IReadOnlyList<Participant> Participants
        {
            get => this.participants.AsReadOnly();
            private set => this.participants = value.ToList();
        }
        public Competition Add(Participant child)
        {
            this.AddOneRelation(x => x.participants, child);
            return this;
        }
        public Competition Remove(Participant child)
        {
            this.RemoveOneRelation(x => x.participants, child);
            return this;
        }

        public Events.Event Event { get; private set; }
        void IDependsOn<Events.Event>.Set(Events.Event domainModel)
            => this.Validate(() =>
            {
                this.Event.IsNotRelated();
                this.Event = domainModel;
            });

        void IDependsOn<Events.Event>.Clear(Events.Event domainModel)
        {
            this.Event = null;
        }
    }
}

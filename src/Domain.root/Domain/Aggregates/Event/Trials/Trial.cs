using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Aggregates.Event.Participants;
using EnduranceContestManager.Domain.Aggregates.Event.Phases;
using EnduranceContestManager.Domain.Enums;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Aggregates.Event.Trials
{
    public class Trial : DomainModel<TrialException>, ITrialState,
        IDependsOn<Contests.Contest>
    {
        public Trial(int id, CompetitionType type) : base(id)
            => this.Validate(() =>
            {
                this.Type = type.IsRequired(nameof(type));
            });

        public CompetitionType Type { get; private set; }

        private readonly List<Phase> phases = new();
        public IReadOnlyList<Phase> Phases => this.phases.AsReadOnly();
        public Trial AddPhase(Phase phase)
        {
            this.Add(trial => trial.phases, phase);
            return this;
        }

        private readonly List<Participant> participants = new();
        public IReadOnlyList<Participant> Participants => this.participants.AsReadOnly();

        public void Add(Participant child)
        {
            throw new System.NotImplementedException();
        }
        public void Remove(Participant child)
        {
            throw new System.NotImplementedException();
        }

        public Contests.Contest Contest { get; private set; }
        void IDependsOn<Contests.Contest>.Set(Contests.Contest domainModel)
            => this.Validate(() =>
            {
                this.Contest.IsNotRelated();
                this.Contest = domainModel;
            });

        void IDependsOn<Contests.Contest>.Clear(Contests.Contest domainModel)
        {
            this.Contest = null;
        }
    }
}

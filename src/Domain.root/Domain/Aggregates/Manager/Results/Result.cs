using EnduranceContestManager.Domain.Aggregates.Manager.Participations;
using EnduranceContestManager.Domain.Core.Validation;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Manager.Results
{
    public class Result : DomainModel<ResultException>,
        IDependsOn<Participation>
    {
        private const string NullParticipationMessage = "Cannot determine result, since participation is null";

        public Result() : base(default)
        {
        }

        public Participation Participation { get; private set; }

        public bool IsSuccessful
        {
            get
            {
                this.Participation.NotDefault(NullParticipationMessage);
                return this.Participation.ParticipationInPhases.All(x => x.ResultInPhase.IsSuccessful);
            }
        }

        void IDependsOn<Participation>.Set(Participation domainModel)
            => this.Except(() =>
            {
                this.Participation.CheckNotRelated();
                this.Participation = domainModel;
            });

        void IDependsOn<Participation>.Clear(Participation domainModel)
        {
            this.Participation = null;
        }
    }
}

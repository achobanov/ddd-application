using EnduranceJudge.Domain.Core.Extensions;
using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Aggregates.Event.Competitions;
using EnduranceJudge.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceJudge.Domain.Aggregates.Event.Participants
{
    public class Participant : DomainModel<ParticipantException>, IParticipantState,
        IDependsOnMany<Competition>
    {
        public Participant(int id, string rfId, int contestNumber) : base(id)
        {
            this.Validate(() =>
            {
                this.RfId = rfId.IsRequired(nameof(rfId));
                this.ContestNumber = contestNumber.IsRequired(nameof(contestNumber));
            });
        }

        public string RfId { get; private set; }
        public int ContestNumber { get; private set; }
        public int? MaxAverageSpeedInKpH { get; private set; }

        public Horse Horse { get; private set; }
        public Participant Set(Horse horse)
        {
            this.SetRelation(
                participant => participant.Horse,
                (participant, h) => participant.Horse = h,
                horse);

            return this;
        }

        public Athlete Athlete { get; private set; }
        public Participant Set(Athlete athlete)
        {
            this.SetRelation(
                participant => participant.Athlete,
                (participant, r) => participant.Athlete = r,
                athlete);

            return this;
        }

        private List<Competition> competitions = new();
        public IReadOnlyList<Competition> Competitions
        {
            get => this.competitions.AsReadOnly();
            private set => this.competitions = value.ToList();
        }
        void IDependsOnMany<Competition>.AddOne(Competition principal)
            => this.Validate(() =>
            {
                this.competitions.ValidateAndAdd(principal);
            });
        void IDependsOnMany<Competition>.RemoveOne(Competition principal)
            => this.Validate(() =>
            {
                this.competitions.ValidateAndRemove(principal);
            });
    }
}

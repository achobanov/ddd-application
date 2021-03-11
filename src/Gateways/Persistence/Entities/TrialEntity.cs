using EnduranceContestManager.Domain.Aggregates.Event.Competitions;
using EnduranceContestManager.Domain.Enums;
using EnduranceContestManager.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceContestManager.Gateways.Persistence.Entities
{
    public class CompetitionEntity : EntityModel<Competition>, ICompetitionState
    {
        public CompetitionEntity()
        {
        }

        [JsonConstructor]
        public CompetitionEntity(int id, int lengthInKilometers, CompetitionType type, int contestId)
            : base(id)
        {
            this.LengthInKilometers = lengthInKilometers;
            this.Type = type;
            this.ContestId = contestId;
        }

        public int LengthInKilometers { get; internal set; }

        public CompetitionType Type { get; internal set; }

        public int ContestId { get; internal set; }

        [JsonIgnore]
        public EventEntity Event { get; internal set; }

        [JsonIgnore]
        public IList<PhaseEntity> Phases { get; internal set; }
    }
}

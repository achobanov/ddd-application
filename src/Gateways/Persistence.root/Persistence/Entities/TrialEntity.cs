using EnduranceContestManager.Domain.Aggregates.Event.Trials;
using EnduranceContestManager.Domain.Enums;
using EnduranceContestManager.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceContestManager.Gateways.Persistence.Entities
{
    public class TrialEntity : EntityModel<Trial>, ITrialState
    {
        public TrialEntity()
        {
        }

        [JsonConstructor]
        public TrialEntity(int id, int lengthInKilometers, CompetitionType type, int contestId)
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
        public ContestEntity Contest { get; internal set; }

        [JsonIgnore]
        public IList<PhaseEntity> Phases { get; internal set; }
    }
}

using EnduranceContestManager.Domain.Models.Trials;
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
        public TrialEntity(int id, int lengthInKilometers, int durationInDays, int contestId)
            : base(id)
        {
            this.LengthInKilometers = lengthInKilometers;
            this.DurationInDays = durationInDays;
            this.ContestId = contestId;
        }

        public int LengthInKilometers { get; internal set; }

        public int DurationInDays { get; internal set; }

        public int ContestId { get; internal set; }

        [JsonIgnore]
        public ContestEntity Contest { get; internal set; }

        [JsonIgnore]
        public IList<PhaseEntity> Phases { get; internal set; }
    }
}

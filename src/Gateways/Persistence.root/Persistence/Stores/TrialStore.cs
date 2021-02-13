using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Phases;
using EnduranceContestManager.Domain.Entities.Trials;
using EnduranceContestManager.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace EnduranceContestManager.Gateways.Persistence.Stores
{
    public class TrialStore : EntityStore<Trial>, ITrialState
    {
        public TrialStore()
        {
        }

        [JsonConstructor]
        public TrialStore(int id, int lengthInKilometers, int durationInDays, int contestId)
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
        public ContestStore Contest { get; internal set; }

        [JsonIgnore]
        public IList<PhaseStore> Phases { get; internal set; }
    }
}

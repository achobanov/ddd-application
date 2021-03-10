using EnduranceContestManager.Domain.Aggregates.Event.Phases;
using EnduranceContestManager.Domain.Aggregates.Event.Competitions;
using EnduranceContestManager.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceContestManager.Gateways.Persistence.Entities
{
    public class PhaseEntity : EntityModel<Phase>, IPhaseState
    {
        public PhaseEntity()
        {
        }

        [JsonConstructor]
        public PhaseEntity(int id, int lengthInKilometers, int trialId)
            : base(id)
        {
            this.LengthInKilometers = lengthInKilometers;
            this.TrialId = trialId;
        }

        public int LengthInKilometers { get; internal set; }

        public bool IsFinal { get; internal set; }

        [JsonIgnore]
        public IList<PhaseForCategoryEntity> PhasesForCategories { get; internal set; }

        public int TrialId { get; internal set; }

        [JsonIgnore]
        public Competition Competition { get; internal set; }
    }
}

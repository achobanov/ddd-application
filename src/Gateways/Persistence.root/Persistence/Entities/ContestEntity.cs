using EnduranceContestManager.Domain.Aggregates.Common;
using EnduranceContestManager.Domain.Aggregates.Event.Contests;
using EnduranceContestManager.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceContestManager.Gateways.Persistence.Entities
{
    public class ContestEntity : EntityModel<Contest>, IContestState
    {
        public ContestEntity()
        {
        }

        [JsonConstructor]
        public ContestEntity(
            int id,
            string name,
            string populatedPlace,
            string presidentGroundJury,
            string feiTechDelegate,
            string feiVetDelegate,
            string presidentVetCommission,
            string foreignJudge,
            string activeVet)
            : base(id)
        {
            this.Name = name;
            this.PopulatedPlace = populatedPlace;
            this.PresidentGroundJury = presidentGroundJury;
            this.FeiTechDelegate = feiTechDelegate;
            this.FeiVetDelegate = feiVetDelegate;
            this.PresidentVetCommission = presidentVetCommission;
            this.ForeignJudge = foreignJudge;
            this.ActiveVet = activeVet;
        }

        public string Name { get; private set; }

        public string PopulatedPlace { get; internal set; }

        public string PresidentGroundJury { get; internal set; }

        public string FeiTechDelegate { get; internal set; }

        public string PresidentVetCommission { get; internal set; }

        public string FeiVetDelegate { get; internal set; }

        public string ForeignJudge { get; internal set; }

        public string ActiveVet { get; internal set; }

        [JsonIgnore]
        public IList<TrialEntity> Trials { get; internal set; }
    }
}

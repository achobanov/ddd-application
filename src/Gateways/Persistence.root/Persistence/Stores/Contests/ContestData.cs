using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Contests;
using EnduranceContestManager.Gateways.Persistence.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceContestManager.Gateways.Persistence.Stores.Contests
{
    public class ContestData : DataEntry, IContestState, IMapFrom<Contest>, IMapTo<Contest>
    {
        public ContestData()
        {
        }

        [JsonConstructor]
        public ContestData(
            int id,
            string name,
            string populatedPlace,
            string country,
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
            this.Country = country;
            this.PresidentGroundJury = presidentGroundJury;
            this.FeiTechDelegate = feiTechDelegate;
            this.FeiVetDelegate = feiVetDelegate;
            this.PresidentVetCommission = presidentVetCommission;
            this.ForeignJudge = foreignJudge;
            this.ActiveVet = activeVet;
        }

        public string Name { get; private set; }

        public string PopulatedPlace { get; internal set; }

        public string Country { get; internal set; }

        public string PresidentGroundJury { get; internal set; }

        public string FeiTechDelegate { get; internal set; }

        public string PresidentVetCommission { get; internal set; }

        public string FeiVetDelegate { get; internal set; }

        public string ForeignJudge { get; internal set; }

        public string ActiveVet { get; internal set; }

        [JsonIgnore]
        public IList<TrialData> Trials { get; internal set; }
    }
}

using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Contests;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnduranceContestManager.Gateways.Persistence.Data.Contests
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

        public string PopulatedPlace { get; private set; }

        public string Country { get; private set; }

        public string PresidentGroundJury { get; private set; }

        public string FeiTechDelegate { get; private set; }

        public string PresidentVetCommission { get; private set; }

        public string FeiVetDelegate { get; private set; }

        public string ForeignJudge { get; private set; }

        public string ActiveVet { get; private set; }

        // public IList<string> MembersOfVetCommittee { get; set; }
        //
        // public IList<string> MembersOfJudgeCommittee { get; set; }
        //
        // public IList<string> Stewards { get; set; }

        public IList<TrialData> Trials { get; private set; }
    }
}

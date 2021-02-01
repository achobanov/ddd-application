using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Domain.Entities.Contests;
using System.Collections.Generic;

namespace EnduranceContestManager.Gateways.Persistence.Data.Contests
{
    public class ContestData : DataEntry, IContestState, IMapFrom<Contest>, IMapTo<Contest>
    {
        public string Name { get; }

        public string PopulatedPlace { get; set; }

        public string Country { get; set; }

        public string PresidentGroundJury { get; set; }

        public string FeiTechDelegate { get; set; }

        public string PresidentVetCommission { get; set; }

        public string FeiVetDelegate { get; set; }

        public string ForeignJudge { get; set; }

        public string ActiveVet { get; set; }

        // public IList<string> MembersOfVetCommittee { get; set; }
        //
        // public IList<string> MembersOfJudgeCommittee { get; set; }
        //
        // public IList<string> Stewards { get; set; }

        public IList<TrialData> Trials { get; set; }
    }
}

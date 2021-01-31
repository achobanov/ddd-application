using EnduranceContestManager.Domain.Entities.Trials;
using EnduranceContestManager.Domain.Interfaces;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Entities.Contests
{
    public interface IContestState : IEntityState
    {
        public string Name { get; }

        public string PopulatedPlace { get; }

        public string Country { get; }

        public string PresidentGroundJury { get; }

        public string FeiTechDelegate { get; }

        public string PresidentVetCommission { get; }

        public string FeiVetDelegate { get; }

        public string ForeignJudge { get; }

        public string ActiveVet { get; }

        IList<string> MembersOfVetCommittee { get; }

        IList<string> MembersOfJudgeCommittee { get; }

        IList<string> Stewards { get; }

        IList<Trial> Trials { get; }
    }
}

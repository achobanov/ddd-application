using EnduranceContestManager.Domain.Core.Entities;
using System;
using System.Collections.Generic;

namespace EnduranceContestManager.Domain.Models.Contest
{
    public class Contest : Entity, IAggregateRoot
    {
        public string Name { get; init; }

        public string PopulatedPlace { get; private set; }

        public string Country { get; private set; }

        public string PresidentGroundJury { get; private set; }

        public string FeiTechDelegate { get; private set; }

        public string PresidentVetCommission { get; private set; }

        public string FeiVetDelegate { get; private set; }

        public string ForeignJudge { get; private set; }

        public IList<string> MembersOfJudgeCommittee { get; private set; }

        public string ActiveVet { get; private set; }

        public IList<string> Stewards { get; private set; }

        public List<Trial> Trials { get; init; }

        public Contest AddTrial(Trial trial)
        {
            this.Trials.Add(trial);
            return this;
        }
    }
}

using EnduranceContestManager.Domain.Aggregates.Contest.ContestPersonnel;
using EnduranceContestManager.Domain.Core.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public List<Personnel> Stewards { get; private set; } = new();

        public Contest AddSteward(Personnel personnel)
        {
            this.Add(x => x.Stewards, personnel);

            return this;
        }

        public Contest RemoveSteward(Func<Personnel, bool> filter)
        {
            var steward = this.MembersOfJudgeCommittee.FirstOrDefault(filter);
            this.Remove(x => x.Stewards, steward);

            return this;
        }
    }
}

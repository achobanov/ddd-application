using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public List<ContestWorker> Stewards { get; private set; } = new();

        public Contest AddSteward(ContestWorker personnel)
        {
            this.Add(this, x => x.Stewards, personnel);

            return this;
        }

        public Contest RemoveSteward(Func<ContestWorker, bool> filter)
        {
            var steward = this.MembersOfJudgeCommittee.FirstOrDefault(filter);
            this.Remove(this, x => x.Stewards, steward);

            return this;
        }
    }
}

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
        public IList<ContestWorker> MembersOfJudgeCommittee { get; private set; } = new List<ContestWorker>();

        public Contest AddMembersOfJudgeCommittee(ContestWorker worker)
        {
            this.MembersOfJudgeCommittee
                .CheckExistingAndAdd<ContestWorker, ContestException>(worker)
                .SetContest(this);

            return this;
        }

        public Contest RemoveMemberOfJudgeCommittee(Func<ContestWorker, bool> filter)
        {
            var worker = this.MembersOfJudgeCommittee.FirstOrDefault(filter);
            this.MembersOfJudgeCommittee
                .CheckNotExistingAndRemove<ContestWorker, ContestException>(worker)
                .ClearContest();

            return this;
        }
    }
}

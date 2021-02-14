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
        public List<ContestWorker> MembersOfJudgeCommittee { get; private set; } = new();

        public Contest AddMembersOfJudgeCommittee(ContestWorker personnel)
        {
            this.Add(
                this,
                contest => contest.MembersOfJudgeCommittee,
                personnel);

            return this;
        }

        public Contest RemoveMemberOfJudgeCommittee(Func<ContestWorker, bool> filter)
        {
            var personnel = this.MembersOfJudgeCommittee.FirstOrDefault(filter);
            this.Remove(
                this,
                contest => contest.MembersOfJudgeCommittee,
                personnel);

            return this;
        }
    }
}

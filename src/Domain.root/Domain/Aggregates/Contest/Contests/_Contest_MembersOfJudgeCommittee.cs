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
        public List<Personnel> MembersOfJudgeCommittee { get; private set; } = new();

        public Contest AddMembersOfJudgeCommittee(Personnel personnel)
        {
            this.Add(
                contest => contest.MembersOfJudgeCommittee,
                personnel);

            return this;
        }

        public Contest RemoveMemberOfJudgeCommittee(Func<Personnel, bool> filter)
        {
            var personnel = this.MembersOfJudgeCommittee.FirstOrDefault(filter);
            this.Remove(
                contest => contest.MembersOfJudgeCommittee,
                personnel);

            return this;
        }
    }
}

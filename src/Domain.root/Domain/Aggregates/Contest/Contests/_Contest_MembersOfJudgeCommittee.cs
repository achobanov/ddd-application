using EnduranceContestManager.Domain.Aggregates.Contest.ContestPersonnel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Contests
{
    public partial class Contest
    {
        private readonly List<Personnel> membersOfJudgeCommittee = new();

        [NotMapped]
        public IReadOnlyList<Personnel> MembersOfJudgeCommittee => this.membersOfJudgeCommittee.AsReadOnly();

        public Contest AddMembersOfJudgeCommittee(Personnel personnel)
        {
            this.Add(
                contest => contest.membersOfJudgeCommittee,
                personnel);

            return this;
        }

        public Contest RemoveMemberOfJudgeCommittee(Func<Personnel, bool> filter)
        {
            var personnel = this.membersOfJudgeCommittee.FirstOrDefault(filter);
            this.Remove(
                contest => contest.membersOfJudgeCommittee,
                personnel);

            return this;
        }
    }
}

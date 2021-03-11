using EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel;
using EnduranceContestManager.Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Event.Events
{
    public partial class Event
    {
        private readonly List<Personnel> membersOfJudgeCommittee = new();

        [NotMapped]
        public IReadOnlyList<Personnel> MembersOfJudgeCommittee => this.membersOfJudgeCommittee.AsReadOnly();

        public Event AddMembersOfJudgeCommittee(Personnel personnel)
        {
            this.Add(
                contest => contest.membersOfJudgeCommittee,
                personnel);

            return this;
        }

        public Event RemoveMemberOfJudgeCommittee(Func<Personnel, bool> filter)
        {
            var personnel = this.membersOfJudgeCommittee.FirstOrDefault(filter);
            this.Remove(
                contest => contest.membersOfJudgeCommittee,
                personnel);

            return this;
        }
    }
}

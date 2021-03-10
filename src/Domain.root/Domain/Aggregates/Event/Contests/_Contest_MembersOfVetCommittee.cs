using EnduranceContestManager.Domain.Aggregates.Event.ContestPersonnel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Event.Contests
{
    public partial class Contest
    {
        private readonly List<Personnel> membersOfVetCommittee = new();

        [NotMapped]
        public IReadOnlyList<Personnel> MembersOfVetCommittee => this.membersOfVetCommittee.AsReadOnly();

        public Contest AddMembersOfVetCommittee(Personnel personnel)
        {
            this.Add(
                contest => contest.membersOfVetCommittee,
                personnel);

            return this;
        }

        public Contest RemoveMemberOfVetCommittee(Func<Personnel, bool> filter)
        {
            var personnel = this.membersOfVetCommittee.FirstOrDefault(filter);
            this.Remove(
                contest => contest.membersOfVetCommittee,
                personnel);

            return this;
        }
    }
}

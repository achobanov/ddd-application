using EnduranceContestManager.Domain.Aggregates.Contest.ContestPersonnel;
using EnduranceContestManager.Domain.Core.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public List<Personnel> MembersOfVetCommittee { get; private set; } = new();

        public Contest AddMembersOfVetCommittee(Personnel personnel)
        {
            this.Add(
                contest => contest.MembersOfVetCommittee,
                personnel);

            return this;
        }

        public Contest RemoveMemberOfVetCommittee(Func<Personnel, bool> filter)
        {
            var personnel = this.MembersOfVetCommittee.FirstOrDefault(filter);
            this.Remove(
                contest => contest.MembersOfVetCommittee,
                personnel);

            return this;
        }
    }
}

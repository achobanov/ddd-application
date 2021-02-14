using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        [NotMapped]
        public List<ContestWorker> MembersOfVetCommittee { get; private set; } = new();

        public Contest AddMembersOfVetCommittee(ContestWorker personnel)
        {
            this.Add(
                this,
                contest => contest.MembersOfVetCommittee,
                personnel);

            return this;
        }

        public Contest RemoveMemberOfVetCommittee(Func<ContestWorker, bool> filter)
        {
            var personnel = this.MembersOfVetCommittee.FirstOrDefault(filter);
            this.Remove(
                this,
                contest => contest.MembersOfVetCommittee,
                personnel);

            return this;
        }
    }
}

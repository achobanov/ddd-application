using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        public IList<ContestWorker> MembersOfVetCommittee { get; private set; } = new List<ContestWorker>();

        public Contest AddMembersOfVetCommittee(ContestWorker worker)
        {
            this.MembersOfVetCommittee
                .CheckExistingAndAdd<ContestWorker, ContestException>(worker)
                .SetContest(this);

            return this;
        }

        public Contest RemoveMemberOfVetCommittee(Func<ContestWorker, bool> filter)
        {
            var worker = this.MembersOfVetCommittee.FirstOrDefault(filter);
            this.MembersOfVetCommittee
                .CheckNotExistingAndRemove<ContestWorker, ContestException>(worker)
                .ClearContest();

            return this;
        }
    }
}

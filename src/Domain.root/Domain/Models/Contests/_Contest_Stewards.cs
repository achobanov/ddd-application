using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        public IList<ContestWorker> Stewards { get; private set; } = new List<ContestWorker>();

        public Contest AddSteward(ContestWorker worker)
        {
            this.Stewards
                .CheckExistingAndAdd<ContestWorker, ContestException>(worker)
                !.SetContest(this);
            return this;
        }

        public Contest RemoveSteward(Func<ContestWorker, bool> filter)
        {
            var steward = this.MembersOfJudgeCommittee.FirstOrDefault(filter);
            this.MembersOfJudgeCommittee
                .CheckNotExistingAndRemove<ContestWorker, ContestException>(steward)
                !.ClearContest();

            return this;
        }
    }
}

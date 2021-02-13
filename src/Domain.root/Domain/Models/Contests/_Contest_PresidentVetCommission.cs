using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Models.Contests.ContestWorkers;

namespace EnduranceContestManager.Domain.Models.Contests
{
    public partial class Contest
    {
        public ContestWorker PresidentVetCommission { get; private set; }

        public Contest SetPresidentVetCommission(ContestWorker presidentVetCommission)
        {
            this.PresidentVetCommission
                .CheckNotNullAndSet<ContestWorker, ContestException>(presidentVetCommission)
                .SetContest(this);

            return this;
        }
    }
}

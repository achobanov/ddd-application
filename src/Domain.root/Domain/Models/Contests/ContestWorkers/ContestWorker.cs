using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Validation;

namespace EnduranceContestManager.Domain.Models.Contests.ContestWorkers
{
    public class ContestWorker : DomainModel<ContestWorkerException>, IContestWorkerState,
        IDependsOn<Contest>
    {
        public ContestWorker(int id, string name)
            : base(id)
        {
            this.Except(() =>
            {
                this.Name = name.CheckPersonName();
            });
        }

        public string Name { get; private set; }

        public Contest Contest { get; private set; }

        void IDependsOn<Contest>.Set(Contest domainModel)
            => this.Except(() =>
            {
                this.Contest.CheckNotRelated();
                this.Contest = domainModel;
            });

        void IDependsOn<Contest>.Clear(Contest domainModel)
        {
            this.Contest = null;
        }
    }
}

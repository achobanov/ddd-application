using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Validation;

namespace EnduranceContestManager.Domain.Aggregates.Contest.ContestPersonnel
{
    public class Personnel : DomainModel<PersonnelException>, IPersonnelState,
        IDependsOn<Contests.Contest>
    {
        public Personnel(int id, string name)
            : base(id)
            => this.Validate(() =>
            {
                this.Name = name.CheckPersonName();
            });

        public string Name { get; private set; }

        public Contests.Contest Contest { get; private set; }
        void IDependsOn<Contests.Contest>.Set(Contests.Contest domainModel)
            => this.Validate(() =>
            {
                this.Contest.IsNotRelated();
                this.Contest = domainModel;
            });
        void IDependsOn<Contests.Contest>.Clear(Contests.Contest domainModel)
        {
            this.Contest = null;
        }
    }
}

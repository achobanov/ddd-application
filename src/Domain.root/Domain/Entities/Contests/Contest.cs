using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Entities.Trials;
using EnduranceContestManager.Domain.Interfaces;
using EnduranceContestManager.Domain.Validation;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Entities.Contests
{
    public class Contest : Entity, IContestState, IAggregateRoot
    {
        public Contest(
            int id,
            string name,
            string populatedPlace,
            string country,
            string presidentGroundJury,
            string feiTechDelegate,
            string feiVetDelegate,
            string presidentVetCommission,
            string foreignJudge,
            string activeVet)
            : base(id)
        {
            this.Name = name;
            this.PopulatedPlace = populatedPlace;
            this.Country = country;
            this.PresidentGroundJury = this.ValidatePersonName(presidentGroundJury);
            this.FeiTechDelegate = this.ValidatePersonName(feiTechDelegate);
            this.FeiVetDelegate = this.ValidatePersonName(feiVetDelegate);
            this.PresidentVetCommission = this.ValidatePersonName(presidentVetCommission);
            this.ForeignJudge = this.ValidatePersonName(foreignJudge);
            this.ActiveVet = this.ValidatePersonName(activeVet);
            // this.MembersOfVetCommittee = this.ValidatePersonName(membersOfVetCommittee);
            // this.MembersOfJudgeCommittee = this.ValidatePersonName(membersOfJudgeCommittee);
            // this.Stewards = this.ValidatePersonName(stewards);
        }

        public string Name { get; private set; }

        public string PopulatedPlace { get; private set; }

        public string Country { get; private set; }

        public string PresidentGroundJury { get; private set; }

        public string FeiTechDelegate { get; private set; }

        public string PresidentVetCommission { get; private set; }

        public string FeiVetDelegate { get; private set; }

        public string ForeignJudge { get; private set; }

        public string ActiveVet { get; private set; }

        public IList<Trial> Trials { get; private set; } = new List<Trial>();

        public Contest AddTrial(Trial trial)
        {
            // TODO: Validations?
            this.Trials.Add(trial);
            return this;
        }

        private IList<string> ValidatePersonName(IList<string> names)
            => names
                .Select(this.ValidatePersonName)
                .ToList();

        private string ValidatePersonName(string name)
        {
            var result = PersonNameValidation<ContestException>.Validate(name);
            return result;
        }
    }
}

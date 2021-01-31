using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Entities.Trials;
using EnduranceContestManager.Domain.Interfaces;
using EnduranceContestManager.Domain.Validation;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceContestManager.Domain.Entities.Contests
{
    public class Contest : Entity, IContestState, IAggregateRoot
    {
        [JsonConstructor]
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
            string activeVet,
            IList<string> membersOfVetCommittee,
            IList<string> stewards,
            IList<Trial> trials)
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
            this.MembersOfVetCommittee = this.ValidatePersonName(membersOfVetCommittee);
            this.Stewards = this.ValidatePersonName(stewards);
            this.Trials = trials;
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

        public IList<string> MembersOfVetCommittee { get; private set; }

        public IList<string> MembersOfJudgeCommittee { get; private set; }

        public IList<string> Stewards { get; private set; }

        public IList<Trial> Trials { get; private set; }

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
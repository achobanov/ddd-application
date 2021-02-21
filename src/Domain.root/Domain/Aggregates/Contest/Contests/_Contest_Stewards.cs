using EnduranceContestManager.Domain.Aggregates.Contest.ContestPersonnel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnduranceContestManager.Domain.Aggregates.Contest.Contests
{
    public partial class Contest
    {
        private readonly List<Personnel> stewards = new();

        [NotMapped]
        public IReadOnlyList<Personnel> Stewards => this.stewards.AsReadOnly();

        public Contest AddSteward(Personnel personnel)
        {
            this.Add(x => x.stewards, personnel);
            return this;
        }

        public Contest RemoveSteward(Func<Personnel, bool> filter)
        {
            var steward = this.stewards.FirstOrDefault(filter);
            this.Remove(x => x.stewards, steward);
            return this;
        }
    }
}

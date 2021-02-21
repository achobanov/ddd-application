using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Validation;
using System;

namespace EnduranceContestManager.Domain.Aggregates.Import.Horses
{
    public class Horse : DomainModel<HorseException>, IHorseState
    {
        public Horse(string name, string gender, bool isStallion, DateTime birthDay, string country, string owner)
            : base(default)
        {
            this.Except(() =>
            {
                this.Name = name.IsRequired(nameof(name));
                this.Gender = gender.CheckValidGender();
                this.BirthDay = birthDay.CheckDateHasPassed();
                this.Owner = owner.IsRequired(nameof(owner));
            });

            this.Country = country;
            this.IsStallion = isStallion;
        }

        public string Name { get; private set; }
        public string Gender { get; private set; }
        public bool IsStallion { get; private set; }
        public DateTime BirthDay { get; private set; }
        public string Country { get; private set; }
        public string Owner { get; private set; }
    }
}

using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Validation;
using EnduranceJudge.Domain.Core.Models;
using System;

namespace EnduranceJudge.Domain.Aggregates.Import.Horses
{
    public class Horse : DomainModel<HorseException>, IHorseState
    {
        public Horse(string name, string gender, bool isStallion, DateTime birthDay, string owner)
            : base(default)
        {
            this.Validate(() =>
            {
                this.Name = name.IsRequired(nameof(name));
                this.Gender = gender.CheckValidGender();
                this.BirthDay = birthDay.HasDatePassed();
                this.Owner = owner.IsRequired(nameof(owner));
            });

            this.IsStallion = isStallion;
        }

        public string Name { get; private set; }
        public string Gender { get; private set; }
        public bool IsStallion { get; private set; }
        public DateTime BirthDay { get; private set; }
        public string Owner { get; private set; }
    }
}

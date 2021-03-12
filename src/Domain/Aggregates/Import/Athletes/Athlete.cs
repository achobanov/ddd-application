using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Validation;
using EnduranceJudge.Domain.Aggregates.Common.Countries;
using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Enums;
using System;

namespace EnduranceJudge.Domain.Aggregates.Import.Athletes
{
    public class Athlete : DomainModel<RiderException>, IAthleteState
    {
        private const int AdultAgeInYears = 18;

        public Athlete(string feiId, string firstName, string lastName, string gender, DateTime birthDate)
            : base(default)
        {
            this.Validate(() =>
            {
                this.FeiId = feiId.IsRequired(nameof(feiId));
                this.FirstName = firstName.IsRequired(nameof(firstName));
                this.LastName = lastName.IsRequired(nameof(lastName));
                this.Gender = gender.CheckValidGender();
                this.BirthDate = birthDate.HasDatePassed();
            });

            this.SetCategory(birthDate);
        }

        public string FeiId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Country Country { get; private set; }
        public void Set(Country country)
            => this.Validate(() =>
            {
                this.Country = country.IsRequired(nameof(country));
            });

        public Category Category { get; private set; }
        private void SetCategory(DateTime birthDate)
        {
            var category = birthDate.AddYears(AdultAgeInYears) <= DateTime.Now
                ? Category.Adults
                : Category.Kids;

            this.Category = category;
        }

    }
}
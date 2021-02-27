using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Enums;
using EnduranceContestManager.Domain.Validation;
using System;

namespace EnduranceContestManager.Domain.Aggregates.Import.Riders
{
    public class Rider : DomainModel<RiderException>, IRiderState
    {
        private const int AdultAgeInYears = 18;

        public Rider(string feiId, string firstName, string lastName, string gender, DateTime birthDate, string country)
            : base(default)
        {
            this.Validate(() =>
            {
                this.FeiId = feiId.IsRequired(nameof(feiId));
                this.FirstName = firstName.IsRequired(nameof(firstName));
                this.LastName = lastName.IsRequired(nameof(lastName));
                this.Gender = gender.CheckValidGender();
                this.BirthDate = birthDate.HasDatePassed();
                this.Country = country; // TODO: countries?
            });

            this.SetCategory(birthDate);
        }

        public string FeiId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Country { get; private set; }
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

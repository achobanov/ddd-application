using EnduranceJudge.Domain.Core.Validation;
using EnduranceJudge.Domain.Core.Models;
using EnduranceJudge.Domain.Enums;
using System;

namespace EnduranceJudge.Domain.Aggregates.Import.Athletes
{
    public class Athlete : DomainBase<RiderException>, IAthleteState
    {
        private const int AdultAgeInYears = 18;

        private Athlete()
        {
        }

        public Athlete(string feiId, string firstName, string lastName, string competingFor, DateTime birthDate)
            : base(default)
        {
            this.Validate(() =>
            {
                birthDate.IsRequired(nameof(birthDate));
                competingFor.IsRequired(nameof(competingFor));

                this.FeiId = feiId.IsRequired(nameof(feiId));
                this.FirstName = firstName.IsRequired(nameof(firstName));
                this.LastName = lastName.IsRequired(nameof(lastName));
                this.CountryIsoCode = competingFor.IsRequired(nameof(competingFor));
            });

            this.SetCategory(birthDate);
        }

        public string FeiId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Category Category { get; private set; }
        public string CountryIsoCode { get; private set; }

        private void SetCategory(DateTime birthDate)
        {
            var category = birthDate.AddYears(AdultAgeInYears) <= DateTime.Now
                ? Category.Adults
                : Category.Kids;

            this.Category = category;
        }
    }
}

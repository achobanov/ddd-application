using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Validation;
using System;

namespace EnduranceContestManager.Domain.Aggregates.Import.Riders
{
    public class Rider : DomainModel<RiderException>, IRiderState, IAggregateRoot
    {
        public Rider(
            int id,
            string feiId,
            string firstName,
            string lastName,
            string gender,
            DateTime birthDate,
            string country)
            : base(id)
        {
            this.Except(() =>
            {
                this.FeiId = feiId.CheckNotDefault(nameof(feiId));
                this.FirstName = firstName.CheckNotDefault(nameof(firstName));
                this.LastName = lastName.CheckNotDefault(nameof(lastName));
                this.Gender = gender.CheckValidGender();
                this.BirthDate = birthDate.CheckDatePassed();
                this.Country = country; // TODO: countries?
            });
        }

        public string FeiId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Country { get; set; }
    }
}

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
                this.FeiId = feiId.IsRequired(nameof(feiId));
                this.FirstName = firstName.IsRequired(nameof(firstName));
                this.LastName = lastName.IsRequired(nameof(lastName));
                this.Gender = gender.CheckValidGender();
                this.BirthDate = birthDate.CheckDateHasPassed();
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

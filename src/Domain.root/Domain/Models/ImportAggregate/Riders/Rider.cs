using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Validation;
using System;

namespace EnduranceContestManager.Domain.Models.ImportAggregate.Riders
{
    public class Rider : DomainModel<RiderException>, IRiderState, IAggregateRoot
    {
        public Rider(
            int id,
            int feiId,
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

        public int FeiId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Country { get; set; }
    }
}

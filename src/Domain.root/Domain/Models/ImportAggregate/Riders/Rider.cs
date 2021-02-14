using EnduranceContestManager.Domain.Core.Entities;
using EnduranceContestManager.Domain.Core.Validation;
using EnduranceContestManager.Domain.Validation;
using System;

namespace EnduranceContestManager.Domain.Models.ImportAggregate.Riders
{
    public class Rider : DomainModel, IRiderState, IAggregateRoot
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
            this.FeiId = feiId.CheckNotDefault<int, RiderException>();
            this.FirstName = firstName.CheckNotDefault<string, RiderException>();
            this.LastName = lastName.CheckNotDefault<string, RiderException>();
            this.Gender = gender.CheckValidGender<RiderException>();
            this.BirthDate = birthDate.CheckDatePassed<RiderException>();
            this.Country = country; // TODO: countries?
        }

        public int FeiId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Country { get; set; }
    }
}

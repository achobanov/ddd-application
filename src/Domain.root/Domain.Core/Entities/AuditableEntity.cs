using EnduranceContestManager.Domain.Core.Exceptions;
using System;

namespace EnduranceContestManager.Domain.Core.Entities
{
    public abstract class AuditableEntity : Entity, IAuditableEntity
    {
        private string createdBy;
        private string modifiedBy;

        public string CreatedBy
        {
            get => this.createdBy;
            set => this.createdBy = value ?? throw new DomainException(this.GetType().Name, nameof(this.CreatedBy));
        }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy
        {
            get => this.modifiedBy;
            set => this.modifiedBy = value;
        }

        public DateTime? ModifiedOn { get; set; }
    }
}

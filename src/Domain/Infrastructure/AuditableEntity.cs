namespace Blog.Domain.Infrastructure
{
    using System;
    using Exceptions;

    public abstract class AuditableEntity : Entity, IAuditableEntity
    {
        private string createdBy;
        private string modifiedBy;

        public string CreatedBy
        {
            get => this.createdBy;
            set => this.createdBy = value ?? throw new InvalidEntityException("User ID cannot be null.");
        }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy
        {
            get => this.modifiedBy;
            set => this.modifiedBy = value ?? throw new InvalidEntityException("User ID cannot be null.");
        }

        public DateTime? ModifiedOn { get; set; }
    }
}

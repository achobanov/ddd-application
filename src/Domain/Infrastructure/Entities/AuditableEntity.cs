﻿using System;

namespace Blog.Domain.Infrastructure.Entities
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
            set => this.modifiedBy = value ?? throw new DomainException(this.GetType().Name, nameof(this.ModifiedBy));
        }

        public DateTime? ModifiedOn { get; set; }
    }
}

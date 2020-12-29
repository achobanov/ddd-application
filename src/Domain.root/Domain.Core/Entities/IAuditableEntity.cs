using System;

namespace EnduranceContestManager.Domain.Core.Entities
{
    public interface IAuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

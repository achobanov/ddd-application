using System;

namespace EnduranceContestManager.Domain.Infrastructure
{
    public class DomainException : Exception
    {
        public const string PropertyIsRequiredMessage = "Property '{1}' on '{0}' is required.";

        public DomainException(string entityName, string propertyName)
            : base(string.Format(PropertyIsRequiredMessage, propertyName, entityName))
            => this.PropertyName = propertyName;

        public DomainException(string entityName, string propertyName, string messageTemplate)
            : base(string.Format(messageTemplate, entityName, propertyName))
            => this.PropertyName = propertyName;

        public string PropertyName { get; }
    }
}

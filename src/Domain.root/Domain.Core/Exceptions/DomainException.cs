using System;

namespace EnduranceContestManager.Domain.Core.Exceptions
{
    public class DomainException : Exception
    {
        public const string PropertyIsRequiredMessage = "Property '{0}' on '{1}' is required.";

        public DomainException(string entityName, string propertyName)
            : base(string.Format(PropertyIsRequiredMessage, propertyName, entityName))
            => this.PropertyName = propertyName;

        public DomainException(string entityName, string propertyName, string messageTemplate)
            : base(string.Format(messageTemplate, entityName, propertyName))
            => this.PropertyName = propertyName;

        public string PropertyName { get; }
    }
}

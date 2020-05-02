using System;

namespace Blog.Domain.Infrastructure
{
    public class DomainException : Exception
    {
        public const string PropertyIsRequiredTemplate = "Property '{0}' is required.";
        public const string PropertyOfEntityIsRequiredTemplate = "Property '{0}' of type '{1} is required.";

        public DomainException(string propertyName)
            : base(string.Format(PropertyIsRequiredTemplate, propertyName))
            => this.PropertyName = propertyName;

        public DomainException(string entityName, string propertyName)
            : base(string.Format(PropertyOfEntityIsRequiredTemplate, propertyName, entityName))
            => this.PropertyName = propertyName;

        public DomainException(string entityName, string propertyName, string messageTemplate)
            : base(string.Format(PropertyOfEntityIsRequiredTemplate, entityName, propertyName))
            => this.PropertyName = propertyName;

        public string PropertyName { get; }
    }
}

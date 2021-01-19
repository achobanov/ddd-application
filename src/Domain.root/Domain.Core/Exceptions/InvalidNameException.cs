namespace EnduranceContestManager.Domain.Core.Exceptions
{
    public class InvalidNameException : DomainException
    {
        private const string InvalidNameTemplate = "Invalid name for {propertyName} in {entityName}";

        public InvalidNameException(string entityName, string propertyName)
            : base(entityName, propertyName)
        {
        }

        public InvalidNameException(string entityName, string propertyName, string messageTemplate)
            : base(entityName, propertyName, messageTemplate)
        {
        }
    }
}

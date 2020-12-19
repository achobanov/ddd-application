using System;
using EnduranceContestManager.Domain.Infrastructure;

namespace EnduranceContestManager.Domain.Authors
{
    public class AuthorException : DomainException
    {
        private static readonly Type Type = typeof(Author);

        public AuthorException(string propertyName)
            : base(Type.Name, propertyName)
        {
        }

        public AuthorException(string propertyName, string messageTemplate)
            : base(Type.Name, propertyName, messageTemplate)
        {
        }
    }
}

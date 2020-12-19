using System;
using EnduranceContestManager.Domain.Infrastructure;

namespace EnduranceContestManager.Domain.Comments
{
    public class CommentException : DomainException
    {

        private static readonly Type Type = typeof(Comment);

        public CommentException(string propertyName)
            : base(Type.Name, propertyName)
        {
        }

        public CommentException(string propertyName, string messageTemplate)
            : base(Type.Name, propertyName, messageTemplate)
        {
        }
    }
}

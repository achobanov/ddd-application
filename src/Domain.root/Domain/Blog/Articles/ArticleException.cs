using System;
using EnduranceContestManager.Domain.Core.Exceptions;

namespace EnduranceContestManager.Domain.Blog.Articles
{
    public class ArticleException : DomainException
    {
        private static readonly Type Type = typeof(Article);

        public ArticleException(string propertyName)
            : base(Type.Name, propertyName)
        {
        }

        public ArticleException(string propertyName, string messageTemplate)
            : base(Type.Name, propertyName, messageTemplate)
        {
        }
    }
}

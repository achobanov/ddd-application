using System;

namespace Blog.Domain.Infrastructure
{
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base(message)
        {

        }
    }
}

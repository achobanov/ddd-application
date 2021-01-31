using System;

namespace EnduranceContestManager.Domain.Core.Exceptions
{
    public abstract class DomainException : Exception
    {
        public string Template { get; set; }

        public string Error
            => string.Format($"{this.Entity}: {this.Template}", this.Arguments);

        public void WithArguments(params object[] arguments)
            => this.Arguments = arguments;

        protected abstract string Entity { get; }

        protected object[] Arguments { get; set; }
    }
}

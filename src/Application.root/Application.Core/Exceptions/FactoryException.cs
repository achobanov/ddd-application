using System;

namespace EnduranceContestManager.Application.Core.Exceptions
{
    public class FactoryException : Exception
    {
        public FactoryException(string entity, string state)
            : base($"Cannot create instance of '{entity}' with state: '{state}'")
        {
        }
    }
}

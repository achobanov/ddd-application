using System;
using Blog.Common.ConventionalServices;

namespace Blog.Common.Contracts
{
    public interface IDateTime : IService
    {
        DateTime Now { get; }
    }
}

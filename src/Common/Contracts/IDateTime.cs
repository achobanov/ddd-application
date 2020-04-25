namespace Blog.Common.Contracts
{
    using System;
    using Blog.Common.ConventionalServices;

    public interface IDateTime : IService
    {
        DateTime Now { get; }
    }
}

namespace Blog.Application.Contracts
{
    using System;
    using Blog.Application.Common.Services;

    public interface IDateTime : IService
    {
        DateTime Now { get; }
    }
}

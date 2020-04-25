namespace Blog.Application.Contracts
{
    using System;
    using Blog.Application.Infrastructure.Services;

    public interface IDateTime : IService
    {
        DateTime Now { get; }
    }
}

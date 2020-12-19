﻿using System.Threading.Tasks;
using EnduranceContestManager.Common.Models;

namespace EnduranceContestManager.Gateways.Web.Contracts
{
    public interface IAuthenticationContract
    {
        Task<Result<string>> Login(ILoginContext model);

        Task Logout();

        Task<Result> Register(IRegisterContext model);
    }

    public interface IRegisterContext
    {
        string Username { get; }

        string Password { get; }
    }

    public interface ILoginContext
    {
        string Username { get; }

        string Password { get; }

        bool RememberMe { get; }
    }
}
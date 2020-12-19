using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EnduranceContestManager.Authentication.Infrastructure
{
    public static class SymmetricKeyFactory
    {
        public static SymmetricSecurityKey Create(string key)
            => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    }
}

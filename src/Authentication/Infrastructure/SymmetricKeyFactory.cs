using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Authentication.Infrastructure
{
    public static class SymmetricKeyFactory
    {
        public static SymmetricSecurityKey Create(string key)
            => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    }
}

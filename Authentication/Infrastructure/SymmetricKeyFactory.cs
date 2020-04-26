using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Gateways.Web.Authentication.Infrastructure
{
    public static class SymmetricKeyFactory
    {
        public static SymmetricSecurityKey Create(string key)
            => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    }
}

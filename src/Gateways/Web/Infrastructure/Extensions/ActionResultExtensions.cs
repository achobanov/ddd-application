using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Gateways.Web.Infrastructure.Extensions
{
    public static class ActionResultExtensions
    {
        public static Task<ActionResult> AsTask(this ActionResult result)
            => Task.FromResult(result);
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Gateways.Web.Infrastructure.Middleware
{
    public class ResponseHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ResponseHandlerMiddleware(RequestDelegate next)
                => this.next = next;

        public async Task Invoke(HttpContext context)
        {
            await next(context);

            await HandleResponse(context);
        }

        public static Task HandleResponse(HttpContext context)
        {
            var response = context.Response;

            if (response.StatusCode == 204)
            {
                var message = "Something went wrong";
                response.ContentType = "application/json";
                var json = JsonConvert.SerializeObject(new { error = new { message } });

                return context.Response.WriteAsync(json);
            }

            return Task.FromResult(context);
        }
    }

    public static class ResponseHanlderExtensions
    {
        public static IApplicationBuilder UseCustomResponseHandlerMiddleware(this IApplicationBuilder builder)
                => builder.UseMiddleware<ResponseHandlerMiddleware>();
    }
}

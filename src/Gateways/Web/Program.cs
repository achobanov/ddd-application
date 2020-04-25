using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Blog.Gateways.Web
{
    public class Program
    {
        public static void Main(string[] args) 
            => CreateWebHostBuilder(args)
                .Build()
                .Initialize()
                .Run();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost
                .CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

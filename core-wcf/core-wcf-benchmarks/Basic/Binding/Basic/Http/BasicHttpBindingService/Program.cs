using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BasicHttpBindingService
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
            .UseStartup<BasicHttpBindingStartup>();
    }
}

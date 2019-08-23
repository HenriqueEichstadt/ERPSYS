using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ERPSYS.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Iniciando o Host Web
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

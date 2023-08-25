using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

// https://www.youtube.com/watch?v=fmvcAzHpsk8&ab_channel=LesJackson
namespace Commander
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}

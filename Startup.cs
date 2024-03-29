using AutoMapper;
using Commander.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Newtonsoft.Json.Serialization;

// https://www.youtube.com/watch?v=fmvcAzHpsk8

namespace Commander
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddDbContext<CommanderContext>(opt =>
          opt.UseSqlServer(Configuration.GetConnectionString("CommanderConnection")));

      // Ovo je za pATCH.....
      services.AddControllers().AddNewtonsoftJson(s =>
        {
          s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        });

      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      // fake data
      // services.AddScoped<ICommanderRepo, MockCommanderRepo>();
      services.AddScoped<ICommanderRepo, SqlCommanderRepo>();

    }

    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}

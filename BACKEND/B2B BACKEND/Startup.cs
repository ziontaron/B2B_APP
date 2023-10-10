using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using B2B_BACKEND.EF;
using B2B_BACKEND.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2B_BACKEND
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

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "B2B_BACKEND", Version = "v1" });
      });
      //services.AddDbContext<B2B_APP_Context>(opt => opt.UseInMemoryDatabase("MyDB"));
      services.AddDbContext<B2B_APP_Context>(opt => opt.UseSqlServer(Configuration.GetConnectionString("rsserver")));

      services.AddCors();



      services.AddTransient<IB2B_APP_Context, B2B_APP_Context>();

      services.AddTransient<IB2B_User_Repo, B2B_User_Repo>();
      services.AddTransient<IB2B_Rel_Acknowledge_Repo, B2B_Rel_Acknowledge_Repo>();
      services.AddTransient<IB2B_ASN_Repo, B2B_ASN_Repo>();
      services.AddTransient<IB2B_Open_POs_Repo, B2B_Open_POs_Repo>();


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "B2B_BACKEND v1"));
      }
      app.UseHttpsRedirection();
      app.UseRouting();

      // global cors policy
      app.UseCors(x => x
          .AllowAnyMethod()
          .AllowAnyHeader()
          .SetIsOriginAllowed(origin => true) // allow any origin
          .AllowCredentials()); // allow credentials



      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}

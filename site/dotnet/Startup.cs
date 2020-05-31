using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Site.Config;
using Site.Repository;
using Site.Services;

namespace Site
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      var configService = new ConfigService { ConnectionString = Configuration["ConnectionString"] };

      services.AddAuthentication("CookieAuthentication")
        .AddCookie("CookieAuthentication", config =>
        {
          config.LoginPath = "/Home/Index";
          config.Cookie.HttpOnly = false;
          config.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        });

      services.AddControllersWithViews()
          .AddRazorRuntimeCompilation();

      var emailConfig = new EmailConfig();
      Configuration.GetSection("EmailConfig").Bind(emailConfig);

      services.AddSingleton<ConfigService>(configService);
      services.AddSingleton<EmailConfig>(emailConfig);

      services.AddScoped<SimulationService>();
      services.AddScoped<UserService>();
      services.AddScoped<MailService>();

      services.AddScoped<SimulationRepository>();
      services.AddScoped<UserRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseStaticFiles();
      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}

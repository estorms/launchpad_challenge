using LaunchpadChallenge.HttpClients;
using LaunchpadChallenge.Interfaces;
using LaunchpadChallenge.Repositories;
using LaunchpadChallenge.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace launchpad_challenge
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation("Configuring services");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<ILaunchpadService, LaunchpadService>();
            services.AddScoped<ISpaceXClient, SpaceXClient>();
            services.AddScoped<ILaunchpadRepo, LaunchpadRepo>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

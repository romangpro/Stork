using Application.Sports;
using AutoMapper;
using FluentValidation.AspNetCore;
using Infrastructure.Sports;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using Utf8Json.Resolvers;
using WebAPI.Register;

namespace WebAPI
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
            //test to check can get secret
            var secrets = Configuration["StorkSecret:ServiceApiKey"];
            var secrets2 = Configuration.GetSection("StorkSecret").Get<StorkSecret>();
            //transient - new one each time
            //scoped - one per request
            //singleton - program lifetime


            //must use Swashbuckle v5 prerelease for ASP.NetCore3.0
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Example API",
                    Version = "v1"
                });
            });

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddAutoMapper(typeof(Startup), typeof(LeagueDao), typeof(LeagueDto));
           
            services.AddDbContext<SportsDbContext>(); // o => o.UseInMemory()//o.UseMemoryCache())   // Scoped! 

            //avoid crowding Startup, by grouping the Registration of Services into some IRegister classes
            foreach (IRegister r in new IRegister[] { new RegisterRepositories(), new RegisterServices() })
            {
                r.Register(services, Configuration);
            }
            
            // default Text.Json doesn't support Dictionary and self-reference, and Newtonsoft is slow
            // Utf8Json MVCFormatter is not supported in ASP.NetCore3.0, so have to use OutputFormatter
            services.AddControllersWithViews()
                .AddFluentValidation()
                .AddMvcOptions(option =>
                {
                    option.OutputFormatters.Clear();
                    option.OutputFormatters.Add(new Utf8JsonOutputFormatter(StandardResolver.Default));
                    option.InputFormatters.Clear();
                    option.InputFormatters.Add(new Utf8JsonInputFormatter());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            
            var swaggerSettings = Configuration.GetSection("SwaggerSettings").Get<SwaggerSettings>();
            app.UseSwagger(c => c.RouteTemplate = "swagger/{documentName}/swagger.json");
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Example API v1"));
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

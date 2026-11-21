using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UNKNOWN_SUN_Api.Security;
using UNKOWNSUN.Data;

namespace UNKNOWN_SUN_Api
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
            var auth0Authority = Configuration["Auth0:Authority"]
                ?? throw new InvalidOperationException("Auth0:Authority configuration is required.");
            var auth0Audience = Configuration["Auth0:Audience"]
                ?? throw new InvalidOperationException("Auth0:Audience configuration is required.");

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = auth0Authority;
                    options.Audience = auth0Audience;
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("delete:catalog", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.AddRequirements(new HasScopeRequirements("delete:catalog", auth0Authority));
                });
            });
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            services.AddDbContext<StoreContext>(options =>
                options.UseSqlite(
                    "Data Source=../Registrar.sqlite",
                    b => b.MigrationsAssembly("UNKNOWN-SUN-Api")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "jet.piranha.Api v1"));
            }

            app.UseHttpsRedirection();

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
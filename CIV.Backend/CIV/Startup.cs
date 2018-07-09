using CIV.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CIV
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var sharedKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Configuration["TokenAuthentication:Key"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o => {
                    o.IncludeErrorDetails = true;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        LifetimeValidator = (before, expires, token, parameters) => expires > DateTime.UtcNow,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateActor = false,
                        ValidateLifetime = true,
                        IssuerSigningKey = sharedKey,
                        //ValidateIssuerSigningKey = true,
                        //ValidAudience = Configuration["TokenAuthentication:Audience"],
                        //ValidIssuer = Configuration["TokenAuthentication:Authority"]
                    };
                    o.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {

                            if (context.HttpContext.WebSockets.IsWebSocketRequest || context.Request.Headers["Accept"] == "text/event-stream")
                            {
                                var accessToken = context.Request.Query["access_token"];
                                if (!string.IsNullOrEmpty(accessToken))
                                {
                                    context.Token = accessToken;
                                }
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireClaim(ClaimTypes.NameIdentifier);
                });
            });
            services.AddSignalR();
            services.AddMvc();
            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins(Configuration["AllowedOrigins"])
                        .AllowCredentials();
                }));

            services.AddSingleton<IAuthorizationHandler, GameCreatorHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseSignalR(routes =>
            {
                routes.MapHub<GameHub>("/gameHub");
            });
            app.UseMvc();
        }
    }
}

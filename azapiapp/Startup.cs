
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace azapiapp
{
    //--------------------------------------------------------------------------------------------------------------
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public int DurationInSeconds { get; set; } = 60 * 60 * 24;
	//----------------------------------------------------------------------------------------------------------
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            Environment = env;
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        //----------------------------------------------------------------------------------------------------------
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

            services.AddControllers();

            services.AddDbContext<Models.TodoContext>(opt =>
                                               opt.UseInMemoryDatabase("TodoList"));

            // Register the Swagger generator, defining 1 or more Swagger documents
            //https://github.com/domaindrivendev/Swashbuckle.AspNetCore

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AZ API V1", Version = "v1" });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri("https://login.microsoftonline.com/2367bdec-cf51-44b1-a8db-3677de1acc38/oauth2/v2.0/authorize"),
                            TokenUrl = new Uri("https://login.microsoftonline.com/2367bdec-cf51-44b1-a8db-3677de1acc38/oauth2/v2.0/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                { "api://a51526b6-9678-43ef-909c-48782b7c37f8/ReadAccess", "Reads the todo list" }
                            }
                        }
                    }
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                     {
                     new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                        {
                        Type = ReferenceType.SecurityScheme,
                        Id = "oauth2"
                        },
                                Scheme = "oauth2",
                                Name = "oauth2",
                                In = ParameterLocation.Header
                     },
                        new List<string>()
                     }
                });
            });

            if (Environment.IsDevelopment())
            {
                // Development configuration
            }
            else
            {
                // Staging/Production configuration
            }
            services.AddApplicationInsightsTelemetry();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //----------------------------------------------------------------------------------------------------------
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
			
			// Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            // specifying the Swagger JSON endpoint.
            // Visit http://localhost:5000/swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AZ API V1");
                //c.RoutePrefix = string.Empty;
                c.OAuthClientId("a51526b6-9678-43ef-909c-48782b7c37f8");
                c.OAuthClientSecret("tqFn8y2__f5~4x_nD8BXkbB3tPcyqd~nRO");
                c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
            }
                );

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

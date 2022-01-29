using HospitalDotNetFinal.BLL.Helpers;
using HospitalDotNetFinal.BLL.Interfaces;
using HospitalDotNetFinal.BLL.Managers;
using HospitalDotNetFinal.DAL;
using HospitalDotNetFinal.DAL.Entities;
using HospitalDotNetFinal.DAL.Repositories;
using JsonApiDotNetCore.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal
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

            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            
            services.AddTransient<IBoalaRepository, BoalaRepository>();
            services.AddTransient<IBoalaManager, BoalaManager>();

            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<ITokenHelper, TokenHelper>();
            services.AddTransient<IPacientRepository, PacientRepository>();
            services.AddTransient<IPacientManager, PacientManager>();

            services.AddTransient<IMedicRepository, MedicRepository>();
            services.AddTransient<IMedicManager, MedicManager>();
            services.AddTransient<InitialSeed>();

            services.AddTransient<IMediciPacientiRepository, MediciPacientiRepository>();
            services.AddTransient<IMediciPacientiManager, MediciPacientiManager>();
            
            // unde am adaugat connection stringul
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnString")));
            services.AddJsonApi<AppDbContext>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalDotNetFinal", Version = "v1" });
            });

            //identity
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            /*services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer("AuthScheme", options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    var secret = Configuration.GetSection("Jwt").GetSection("Token").Get<String>();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                    
                options.Events = new List<JwtBearerEvents>
                {
                    new JwtBearerEvents
                    {

                        OnTokenValidated = context =>
                        { 
                            var appIdentity = new ClaimsIdentity(claims,
                            JwtBearerDefaults.AuthenticationScheme);
                            context.Principal.AddIdentity(appIdentity);

                            return Task.CompletedTask;
                        }
                    },

                    new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    }
                };
                });*/

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer("AuthScheme", options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    var secret = Configuration.GetSection("Jwt").GetSection("Token").Get<String>();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization(options =>
            {

                options.AddPolicy("Admin",
                    authBuilder =>
                    {
                        authBuilder.RequireRole("Admin").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build();
                        /*authBuilder.RequireRole("Guest").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build();*/
                    });

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, InitialSeed initialSeed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalDotNetFinal v1"));
            }
            
            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseJsonApi();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            initialSeed.CreateRoles();
        }
    }
}

using DataLayer;
using DataLayer.Repositories.Abstract;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Services;
using Services.Abstract;
using System;
using System.IO;

namespace AutoStoreAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            var authOptionsConfiguration = Configuration.GetSection("Auth");
            services.AddControllers();
            services.AddDbContext<Context>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("AutoStoreDb"));
            });
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ICustomersService, CustomerService>();
            services.AddTransient<IProductSrvice, ProductService>();
            services.Configure<AuthOptions>(authOptionsConfiguration);
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();

                });
            });

            var authOptions = authOptionsConfiguration.Get<AuthOptions>();
            authOptions.Secret = Environment.GetEnvironmentVariable("Secret");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptions.Issure,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),

                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,

                        ValidateLifetime = true,
                    };
                });


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using amina_WebApplication.Models;
using aminaApplication.Dapper.Interfaces;
using aminaApplication.Dapper.Repository;
using aminaApplication.Domain.Models;
using Dapper.FastCrud;
using DapperExtensions.Sql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace amina_WebApplication
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
          
            #region JWT

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
            #endregion
          


            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            string dbConnectionString = this.Configuration.GetConnectionString("Database");
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            }));
            
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "ASP.NET Core Web API"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
 {
     {
           new OpenApiSecurityScheme
             {
                 Reference = new OpenApiReference
                 {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                 },
                 Scheme = "oauth2",
                 Name = "Bearer",
                 In = ParameterLocation.Header
             },
             new string[] {}
     }
 });
            });
            OrmConfiguration.DefaultDialect = SqlDialect.PostgreSql;
            
            services.AddControllers()
                   .ConfigureApiBehaviorOptions(options =>
                   {
                       options.SuppressModelStateInvalidFilter = true;
                   });
            services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;

            });
            
            
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            
            services.AddTransient<IRepositoryGeneric<City>, RepositoryGeneric<City>>();
            services.AddTransient<IRepositoryGeneric<Country>, RepositoryGeneric<Country>>();
            services.AddTransient<IRepositoryGeneric<Permission>, RepositoryGeneric<Permission>>();
            services.AddTransient<IRepositoryGeneric<Role>, RepositoryGeneric<Role>>();
            services.AddTransient<IRepositoryGeneric<User>, RepositoryGeneric<User>>();
            services.AddTransient<IRepositoryGeneric<RolePermission>, RepositoryGeneric<RolePermission>>();

            services.AddScoped<IRepositoryCountry,RepositoryCountry>();
            services.AddScoped<IRepositoryCity, RepositoryCity>();
            services.AddScoped<IRepositoryPermission, RepositoryPermission>();
            services.AddScoped<IRepositoryRole, RepositoryRole>();
            services.AddScoped<IRepositoryUser, RepositoryUser>();
            services.AddScoped<IRepositoryRolePermission, RepositoryRolePermission>();
            services.AddScoped<IRepositoryLogin, RepositoryLogin>();
            services.AddScoped<IRepositoryUserProfile, RepositoryUserProfile>();
            services.AddControllers(x => x.AllowEmptyInputInBodyModelBinding = true);

            services.AddMvc(x => x.EnableEndpointRouting = false).AddNewtonsoftJson(options => 
            { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("AllowCORS");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWTAuthDemo v1");
                c.RoutePrefix = string.Empty;
            });
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();
        }
    }
}

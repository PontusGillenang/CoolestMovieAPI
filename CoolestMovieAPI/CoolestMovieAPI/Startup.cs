using AutoMapper;
using CoolestMovieAPI.MovieDbContext;
using CoolestMovieAPI.Services;
using CoolestTrailerAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CoolestMovieAPI
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MovieContext>();
            
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IMovieDirectorsRepository, MovieDirectorsRepository>();
            services.AddScoped<ITrailerRepository, TrailerRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            
            services.AddAutoMapper(typeof(Startup));

            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("config.json");
                var config = builder.Build();
                
                options.Authority = config.GetSection("Auth0").GetSection("Domain").Value;
                options.Audience = config.GetSection("Auth0").GetSection("Audience").Value;
            });

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    });


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API V1");
            });

            app.UseMvc();
        }
    }
}

using CoolestMovieAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.MovieDbContext
{
    public class MovieContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MovieContext(IConfiguration config, DbContextOptions options) : base(options)
        {
            _configuration = config;
        }
        
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }

        //public DbSet<Actor> Actors { get; set; }
        //public DbSet<Director> Directors { get; set; }
        //public DbSet<Trailer> Trailers { get; set; }
        //public DbSet<MovieActor> MovieActors { get; set; }
        //public DbSet<MovieDirector> MovieDirectors { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CoolestMovieApiDB"));
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("config.json");
            var config = builder.Build();
            var defaultConnectionString = config.GetConnectionString("CoolestMovieApiDB");
            optionsBuilder.UseSqlServer(defaultConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Movie>()
                .HasData(new
                { 
                    MovieID = 1,
                    MovieTitle = "Fight Club",
                    MovieLength = new TimeSpan(2, 10, 00),
                    MovieRating = 8.8,
                    MovieDescription = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.",
                    MovieReleaseYear = 1999
                }, new
                {
                    MovieID = 2,
                    MovieTitle = "Godfather",
                    MovieLength = new TimeSpan(2, 55, 00),
                    MovieRating = 9.2,
                    MovieDescription = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                    MovieReleaseYear = 1972
                }
                );
        }
    }
}

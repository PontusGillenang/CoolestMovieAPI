using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoolestMovieAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolestMovieAPI
{
    public class MovieDbContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //make the colums unique
            modelBuilder.Entity<MovieDirector>().HasKey(x => new { x.MovieID, x.DirectorID });
        }

    }
}

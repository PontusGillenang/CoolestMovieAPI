﻿// <auto-generated />
using System;
using CoolestMovieAPI.MovieDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoolestMovieAPI.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20200507113124_RemovedNamePropActor")]
    partial class RemovedNamePropActor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.3.20181.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoolestMovieAPI.Models.Actor", b =>
                {
                    b.Property<int>("ActorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActorBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ActorCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActorFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActorLastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorID");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("CoolestMovieAPI.Models.Director", b =>
                {
                    b.Property<int>("DirectorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DirectorBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DirectorCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DirectorID");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("CoolestMovieAPI.Models.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreID");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("CoolestMovieAPI.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MovieDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("MovieLength")
                        .HasColumnType("time");

                    b.Property<double>("MovieRating")
                        .HasColumnType("float");

                    b.Property<int>("MovieReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieID");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieID = 1,
                            MovieDescription = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.",
                            MovieLength = new TimeSpan(0, 2, 10, 0, 0),
                            MovieRating = 8.8000000000000007,
                            MovieReleaseYear = 1999,
                            MovieTitle = "Fight Club"
                        },
                        new
                        {
                            MovieID = 2,
                            MovieDescription = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                            MovieLength = new TimeSpan(0, 2, 55, 0, 0),
                            MovieRating = 9.1999999999999993,
                            MovieReleaseYear = 1972,
                            MovieTitle = "Godfather"
                        });
                });

            modelBuilder.Entity("CoolestMovieAPI.Models.MovieActor", b =>
                {
                    b.Property<int>("MovieActorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActorID")
                        .HasColumnType("int");

                    b.Property<int?>("MovieID")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieActorID");

                    b.HasIndex("ActorID");

                    b.HasIndex("MovieID");

                    b.ToTable("MovieActors");
                });

            modelBuilder.Entity("CoolestMovieAPI.Models.MovieDirector", b =>
                {
                    b.Property<int>("MovieDirectorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DirectorID")
                        .HasColumnType("int");

                    b.Property<int?>("MovieID")
                        .HasColumnType("int");

                    b.HasKey("MovieDirectorID");

                    b.HasIndex("DirectorID");

                    b.HasIndex("MovieID");

                    b.ToTable("MovieDirectors");
                });

            modelBuilder.Entity("CoolestMovieAPI.Models.MovieGenre", b =>
                {
                    b.Property<int>("MovieGenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GenreID")
                        .HasColumnType("int");

                    b.Property<int?>("MovieID")
                        .HasColumnType("int");

                    b.HasKey("MovieGenreID");

                    b.HasIndex("GenreID");

                    b.HasIndex("MovieID");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("CoolestMovieAPI.Models.Trailer", b =>
                {
                    b.Property<int>("TrailerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MovieID")
                        .HasColumnType("int");

                    b.Property<string>("TrailerTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrailerUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrailerID");

                    b.HasIndex("MovieID");

                    b.ToTable("Trailers");
                });

            modelBuilder.Entity("CoolestMovieAPI.Models.MovieActor", b =>
                {
                    b.HasOne("CoolestMovieAPI.Models.Actor", "Actor")
                        .WithMany("MovieActors")
                        .HasForeignKey("ActorID");

                    b.HasOne("CoolestMovieAPI.Models.Movie", "Movie")
                        .WithMany("MovieActors")
                        .HasForeignKey("MovieID");
                });

            modelBuilder.Entity("CoolestMovieAPI.Models.MovieDirector", b =>
                {
                    b.HasOne("CoolestMovieAPI.Models.Director", "Director")
                        .WithMany("MovieDirectors")
                        .HasForeignKey("DirectorID");

                    b.HasOne("CoolestMovieAPI.Models.Movie", "Movie")
                        .WithMany("MovieDirectors")
                        .HasForeignKey("MovieID");
                });

            modelBuilder.Entity("CoolestMovieAPI.Models.MovieGenre", b =>
                {
                    b.HasOne("CoolestMovieAPI.Models.Genre", "Genre")
                        .WithMany("MovieGenre")
                        .HasForeignKey("GenreID");

                    b.HasOne("CoolestMovieAPI.Models.Movie", "Movie")
                        .WithMany("MovieGenre")
                        .HasForeignKey("MovieID");
                });

            modelBuilder.Entity("CoolestMovieAPI.Models.Trailer", b =>
                {
                    b.HasOne("CoolestMovieAPI.Models.Movie", null)
                        .WithMany("Trailers")
                        .HasForeignKey("MovieID");
                });
#pragma warning restore 612, 618
        }
    }
}

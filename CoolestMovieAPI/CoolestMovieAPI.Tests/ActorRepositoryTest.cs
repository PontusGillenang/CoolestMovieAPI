using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using CoolestMovieAPI.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace CoolestMovieAPI.Tests
{
    public class ActorRepositoryTest
    {

        [Fact]
        public async void GetAllActors_validData_true()
        {
            // Arrange
            IList<Actor> actors = GenerateActors();
            var movieContextMock = new Mock<MovieContext>();
            movieContextMock.Setup(d => d.Actors).ReturnsDbSet(actors);

            var logger = Mock.Of<ILogger<ActorRepository>>();
            var actorRepository = new ActorRepository(movieContextMock.Object, logger);
            // Act
            var allActors = await actorRepository.GetAllActors();

            // Assert
            Assert.Equal(3, allActors.Count);
        }


        private static IList<Actor> GenerateActors()
        {
            return new List<Actor>
            {
                new Actor
                {
                  ActorID=1,
                  FirstName="Brad",
                  LastName="Pitt",
                  ActorBirthDate=new DateTime (1963,12,18),
                  ActorCountry="Usa",                 
                },
                   new Actor
                {
                  ActorID=2,
                  FirstName="Alicia",
                  LastName="Vikander",
                  ActorBirthDate=new DateTime (1988,11,03),
                  ActorCountry="Sweden",
                },
                      new Actor
                {
                  ActorID=3,
                  FirstName="Angelina",
                  LastName="Jolie",
                  ActorBirthDate=new DateTime (1975,06,04),
                  ActorCountry="Usa",
                }

            };
        }
    }
}

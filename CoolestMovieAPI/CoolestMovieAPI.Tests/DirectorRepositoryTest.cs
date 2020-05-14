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
    public class DirectorRepositoryTest
    {
        [Fact]
        public async void I_O_E()
        {
            // Arrange
            IList<Director> directors = GenerateDirectors();
            var movieContextMock = new Mock<MovieContext>();
            movieContextMock.Setup(d => d.Directors).ReturnsDbSet(directors);

            var logger = Mock.Of<ILogger<DirectorRepository>>();
            var directorRepository = new DirectorRepository(movieContextMock.Object, logger);
            // Act
            var allDirectors = await directorRepository.GetAllDirectors();

            // Assert
            Assert.Equal(1, allDirectors.Count);
        }

        private static IList<Director> GenerateDirectors()
        {
            return new List<Director>
            {
                new Director
                {
                    DirectorID = 1,
                    DirectorName = "Dan",
                    DirectorBirthDate = new DateTime(1943,8,13),
                    DirectorCountry = "Belgium",
                    MovieDirectors = null
                }
            };
        }
    }
}

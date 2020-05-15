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
        public async void GetAllDirectors_ReturnAllDirectors_OrderedById()
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
            Assert.Equal(3, allDirectors.Count);
            Assert.Equal(1, allDirectors[0].DirectorID);
            Assert.Equal(2, allDirectors[1].DirectorID);
            Assert.Equal(3, allDirectors[2].DirectorID);
            Assert.Equal("Kathryn Bigelow", allDirectors[0].DirectorName);
            Assert.Equal("Guy Ritchie", allDirectors[1].DirectorName);
            Assert.Equal("James Cameron", allDirectors[2].DirectorName);
        }

        private static IList<Director> GenerateDirectors()
        {
            return new List<Director>
            {
                new Director
                {
                    DirectorID = 1,
                    DirectorName = "Kathryn Bigelow",
                    DirectorBirthDate = new DateTime(1951,11,27),
                    DirectorCountry = "Belgium",
                    MovieDirectors = null
                },

                new Director
                {
                    DirectorID = 2,
                    DirectorName = "Guy Ritchie",
                    DirectorBirthDate = new DateTime(1968,9,10),
                    DirectorCountry = "England",
                    MovieDirectors = null
                },

                new Director
                {
                    DirectorID = 3,
                    DirectorName = "James Cameron",
                    DirectorBirthDate = new DateTime(1954,8,16),
                    DirectorCountry = "Canada",
                    MovieDirectors = null
                }
            };
        }
    }
}

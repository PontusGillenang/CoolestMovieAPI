using CoolestMovieAPI.Controllers;
using CoolestMovieAPI.Models;
using CoolestMovieAPI.MovieDbContext;
using CoolestMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoolestMovieAPI.Tests
{
    public class DirectorsControllerTest
    {
        [Fact]
        public async Task GetAll_ReturnsOK()
        {
            // Arange
            var directorRepositoryMock = new Mock<IDirectorRepository>();
            directorRepositoryMock.Setup(repo => repo.GetAllDirectors()).ReturnsAsync((IList<Director>)null);
            var controller = new DirectorsController(directorRepositoryMock.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }

}

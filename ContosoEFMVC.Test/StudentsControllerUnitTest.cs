using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoEFMvc.Controllers;
using ContosoEFMvc.Data;
using ContosoEFMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ContosoEFMVC.Test
{
    [Collection("TestFixtureCollection")]
    public class StudentsControllerUnitTest
    {
        private ServiceProvider _serviceProvider;
        private SchoolContext _schoolContext;
        private readonly ILogger<Students> _logger;
        public StudentsControllerUnitTest(TestFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _schoolContext = _serviceProvider.GetRequiredService<SchoolContext>();
            _logger = _serviceProvider.GetRequiredService<ILogger<Students>>();
        }
        [Fact]
        public async Task Index_Returns_Expected_Values()
        {
            //Arrange
            var controller = new Students(_logger, _schoolContext);


            //Act
            var result = await controller.Index();


            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Student>>(viewResult.ViewData.Model);
            Assert.Equal(8, model.Count());
        }
    }
}
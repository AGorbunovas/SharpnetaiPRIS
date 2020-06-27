using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using PRIS.WEB.Controllers;
using PRIS.WEB.Data;
using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PRIS.Test.Controller
{
    public class TestControllerShould
    {
        [Fact]
        public void ReturnViewForTest()
        {
            var sut = new TestController(GetContextWithData());

            IActionResult result = sut.Test();

            Assert.IsType<ViewResult>(result);
        }

        private ApplicationDbContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);

            context.Cities.Add(new City { CityName = "Vilnius" });

            return context;
        }

    }


}

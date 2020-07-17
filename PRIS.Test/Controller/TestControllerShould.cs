using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using PRIS.WEB.Controllers;
using PRIS.WEB.Data;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels.TestViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Xunit;

namespace PRIS.Test.Controller
{
    public class TestControllerShould
    {
        private ApplicationDbContext _context;
        private TestController _sut;

        public TestControllerShould()
        {
            _context = InMemoryApplicationDbContext.GetInMemoryApplicationDbContext();
            _sut = new TestController(_context);
        }

        [Fact]
        public void ReturnViewForTestAction()
        {
            // act
            IActionResult result = _sut.Test();

            // assert
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Test", viewResult.ViewName);
        }

        [Fact]
        public void AddNewValidTestRecordToDb()
        {
            //arrange
            City city = new City { CityName = "Vilnius" };
            _context.Cities.Add(city);
            _context.SaveChanges();
            var viewModel = new AddTestViewModel { CityName = "Vilnius", DateOfTest = DateTime.Today, ClassYearStart = DateTime.Today, ClassYearEnd = DateTime.Today.AddMonths(10) };

            //act
            IActionResult result = _sut.Test(viewModel);

            //assert
            var actual = _context.Test.FirstOrDefault(x => x.TestId == 1);
            Assert.Equal("Vilnius", actual.City.CityName);
        }

        [Fact]
        public void NotAddInvalidTestRecordToDb()
        {
            //arrange
            var viewModel = new AddTestViewModel();

            //act
            IActionResult result = _sut.Test(viewModel);

            //assert
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            var isModelStateValid = viewResult.ViewData.ModelState.IsValid;
            Assert.False(isModelStateValid);
            var testCount = _context.Test.Count();
            Assert.Equal(0, testCount);
        }

        [Fact]
        public void NotAddTestRecordIfDublicated()
        {
            // arrange
            City city = new City { CityName = "Vilnius" };
            _context.Cities.Add(city);
            _context.SaveChanges();
            var viewModel = new AddTestViewModel { CityName = "Vilnius", DateOfTest = DateTime.Today, ClassYearStart = DateTime.Today, ClassYearEnd = DateTime.Today.AddMonths(10) };

            //act
            _sut.Test(viewModel);
            _sut.Test(viewModel);

            //assert
            var testCount = _context.Test.Count();
            Assert.Equal(1, testCount);
        }


        [Fact]
        public void NotAddTestRecordIfDateOfTestIsYesterday()
        {
            // arrange
            City city = new City { CityName = "Vilnius" };
            _context.Cities.Add(city);
            _context.SaveChanges();
            var viewModel = new AddTestViewModel { CityName = "Vilnius", DateOfTest = DateTime.Today.AddDays(-1), ClassYearStart = DateTime.Today, ClassYearEnd = DateTime.Today.AddMonths(10) };

            //act
            _sut.Test(viewModel);

            //assert
            var testCount = _context.Test.Count();
            Assert.Equal(0, testCount);
        }

        [Fact]
        public void NotAddTestRecordIfDateOfTestIsAfterClassYearStartDate()
        {
            // arrange
            City city = new City { CityName = "Vilnius" };
            _context.Cities.Add(city);
            _context.SaveChanges();
            var viewModel = new AddTestViewModel { CityName = "Vilnius", DateOfTest = DateTime.Today.AddDays(1), ClassYearStart = DateTime.Today, ClassYearEnd = DateTime.Today.AddMonths(10) };

            //act
            _sut.Test(viewModel);

            //assert
            var testCount = _context.Test.Count();
            Assert.Equal(0, testCount);

        }

        [Fact]
        public void NotAddTestRecordIfClassYearStartIsAfterClassYearEnd()
        {
            // arrange
            City city = new City { CityName = "Vilnius" };
            _context.Cities.Add(city);
            _context.SaveChanges();
            var viewModel = new AddTestViewModel { CityName = "Vilnius", DateOfTest = DateTime.Today.AddDays(1), ClassYearStart = DateTime.Today, ClassYearEnd = DateTime.Today.AddMonths(-10) };

            //act
            _sut.Test(viewModel);

            //assert
            var testCount = _context.Test.Count();
            Assert.Equal(0, testCount);
        }

    }


}

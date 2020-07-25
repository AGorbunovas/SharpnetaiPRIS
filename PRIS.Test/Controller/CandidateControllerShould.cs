using Microsoft.AspNetCore.Mvc;
using Moq;
using PRIS.WEB.Controllers;
using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Logic;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels;
using PRIS.WEB.ViewModels.CandidateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PRIS.Test.Controller
{
    public class CandidateControllerShould
    {
        private ApplicationDbContext _context;
        private CandidateController _sut;

        public CandidateControllerShould()
        {
            var MockCandidateTestResultProcessor = new Mock<ICandidateTestResultProcessor>();
            MockCandidateTestResultProcessor.Setup(x => x.ValidateTestResultsToTestResultLimits(It.IsAny<List<TaskResultLimit>>(), It.IsAny<TaskResultViewModel>())).Returns(value: null);

            _context = InMemoryApplicationDbContext.GetInMemoryApplicationDbContext();
            _sut = new CandidateController(_context, MockCandidateTestResultProcessor.Object);
        }

        [Fact]
        public void AddTaskResultDisplayCandidateIfCandidateExists()
        {
            //Arrange
            Candidate candidate = new Candidate { CandidateID = 1, FirstName = "Foo", LastName = "Bar", PhoneNumber = 11111111, Test = null };
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
            AddTaskResultLimits(_context);

            //Act
            IActionResult result = _sut.AddTaskResult(1);

            //Act
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            var candidateExists = _context.Candidates.FirstOrDefault(x => x.CandidateID == 1);
            Assert.NotNull(candidateExists);
        }

        [Fact]
        public void AddTaskResultRedirectIfCandidateDoesNotExists()
        {
            //Act
            IActionResult result = _sut.AddTaskResult(1);

            //Assert
            RedirectToActionResult viewResult = Assert.IsType<RedirectToActionResult>(result);

            var ActionName = viewResult.ActionName;
            Assert.Equal("List", ActionName);

            var candidateExists = _context.Candidates.FirstOrDefault(x => x.CandidateID == 1);
            Assert.Null(candidateExists);
        }

        [Fact]
        public void AddTaskResultPostAddInitialTestResults()
        {
            TaskResultViewModel taskResultViewModel = new TaskResultViewModel();

            for (int i = 0; i < 10; i++)
            {
                _context.TaskResultLimits.Add(new TaskResultLimit { MaxValue = 1 });
                _context.SaveChanges();
            }

            IActionResult result = _sut.AddTaskResult(taskResultViewModel, 1);
        }

        [Fact]
        public void DisplayListWithNewestTestOnly()
        {
            //Arrange
            City city = new City { CityName = "Vilnius" };
            _context.Cities.Add(city);

            var firstTest = new PRIS.WEB.Models.Test { City = city, DateOfTest = DateTime.Today };
            var secondTest = new PRIS.WEB.Models.Test { City = city, DateOfTest = DateTime.Today.AddDays(1) };
            _context.AddRange(firstTest, secondTest);

            Candidate candidateFirst = new Candidate { CandidateID = 1, FirstName = "Foo", LastName = "Bar", PhoneNumber = 11111111, Test = firstTest };
            Candidate candidateSecond = new Candidate { CandidateID = 2, FirstName = "Foo", LastName = "Bar", PhoneNumber = 11111111, Test = secondTest };
            _context.AddRange(candidateFirst, candidateSecond);
            _context.SaveChanges();

            //Act
            IActionResult result = _sut.List("Vilnius");
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            List<ListCandidateViewModel> test = viewResult.ViewData.Model as List<ListCandidateViewModel>;

            Assert.Equal(candidateSecond.CandidateID, test[0].CandidateID);
        }

        [Fact]
        public void NotDisplayListWithOldTests()
        {
            //Arrange
            City city = new City { CityName = "Vilnius" };
            _context.Cities.Add(city);

            var firstTest = new PRIS.WEB.Models.Test { City = city, DateOfTest = DateTime.Today };
            var secondTest = new PRIS.WEB.Models.Test { City = city, DateOfTest = DateTime.Today.AddDays(1) };
            _context.AddRange(firstTest, secondTest);

            Candidate candidateFirst = new Candidate { CandidateID = 1, FirstName = "Foo", LastName = "Bar", PhoneNumber = 11111111, Test = firstTest };
            Candidate candidateSecond = new Candidate { CandidateID = 2, FirstName = "Foo", LastName = "Bar", PhoneNumber = 11111111, Test = secondTest };
            _context.AddRange(candidateFirst, candidateSecond);
            _context.SaveChanges();

            //Act
            IActionResult result = _sut.List("Vilnius");

            //Assert
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            List<ListCandidateViewModel> test = viewResult.ViewData.Model as List<ListCandidateViewModel>;

            Assert.NotEqual(candidateFirst.CandidateID, test[0].CandidateID);
        }

        private void AddTaskResultLimits(ApplicationDbContext _context)
        {
            for (int i = 0; i < 10; i++)
            {
                TaskResultLimit taskResultLimit = new TaskResultLimit();
                _context.TaskResultLimits.Add(taskResultLimit);
                _context.SaveChanges();
            }
            
        }


    }
}

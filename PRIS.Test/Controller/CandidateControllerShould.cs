using Microsoft.AspNetCore.Mvc;
using Moq;
using PRIS.WEB.Controllers;
using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Logic;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels;
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
            //ICandidateTestResultProcessor candidateTestResultProcessor = new CandidateTestResultProcessor();
            var MockCandidateTestResultProcessor = new Mock<ICandidateTestResultProcessor>();
            MockCandidateTestResultProcessor.Setup(x => x.ValidateTestResultsToTestResultLimits(It.IsAny<List<TaskResultLimit>>(), It.IsAny<TaskResultViewModel>())).Returns(value: null);

            _context = InMemoryApplicationDbContext.GetInMemoryApplicationDbContext();
            _sut = new CandidateController(_context, MockCandidateTestResultProcessor.Object);
        }

        [Fact]
        public void AddTaskResultDisplayCandidateIfCandidateExists()
        {
            //Arrange
            Candidate candidate = new Candidate {CandidateID=1 ,FirstName = "Foo", LastName = "Bar", PhoneNumber = 11111111, Test = null };
            _context.Candidates.Add(candidate);
            _context.SaveChanges();

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
            TaskResultViewModel taskResultViewModel = new TaskResultViewModel ();

            for (int i = 0; i < 10; i++)
            {
                _context.TaskResultLimits.Add(new TaskResultLimit { MaxValue = 1 });
                _context.SaveChanges();
            }

            IActionResult result = _sut.AddTaskResult(taskResultViewModel, 1);
        }


    }
}

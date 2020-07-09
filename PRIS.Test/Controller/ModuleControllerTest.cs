using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRIS.WEB.Controllers;
using PRIS.WEB.Data;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels.ModuleViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PRIS.Test.Controller
{
    public class ModuleControllerTest : IDisposable
    {
        protected readonly ApplicationDbContext _context;
        //protected readonly SettingsController _settingsController;

        public ModuleControllerTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);

            _context.Database.EnsureCreated();
            //_settingsController = new SettingsController(_context);

            var modules = new[]
            {
                new Module { ModuleID = 1, ModuleName = ".NET"},
                new Module { ModuleID = 2, ModuleName = "QA"}
            };
        }

        [Fact]
        public void ReturnViewForModuleAction()
        {
            ////Arrange
            //var controller = new SettingsController(_context);

            //// Act
            //var result = controller.Module();
            ////IActionResult result = _settingsController.Module();

            //// Assert
            //var objectResult = Assert.IsType<OkObjectResult>(result);
            //Assert.IsAssignableFrom<IEnumerable<Module>>(objectResult.Value);
            ////ViewResult viewResult = Assert.IsType<ViewResult>(result);
            ////Assert.Equal("Module", viewResult.ViewName);
        }

        //[Fact]
        //public void AddNewValidModuleRecordToDb()
        //{
        //    //arrange
        //    Module module = new Module { ModuleName = ".NET" };
        //    _context.Modules.Add(module);
        //    _context.SaveChanges();
        //    var viewModel = new AddModuleViewModel { ModuleName = ".NET" };

        //    //act
        //    IActionResult result = _settingsController.ModuleCreate(viewModel);

        //    //assert
        //    var actual = _context.Modules.FirstOrDefault(x => x.ModuleName == ".NET");
        //    Assert.Equal(".NET", actual.ModuleName);
        //}

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
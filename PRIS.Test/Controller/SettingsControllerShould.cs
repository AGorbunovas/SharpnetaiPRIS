using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRIS.WEB.Controllers;
using PRIS.WEB.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PRIS.Test.Controller
{
    public class SettingsControllerShould
    {
        private ApplicationDbContext _context;
        private SettingsController _settingsController;

        public SettingsControllerShould()
        {
            _context = InMemoryApplicationDbContext.GetInMemoryApplicationDbContext();
            _settingsController = new SettingsController(_context);
        }

        [Fact]
        public void ReturnCityViewForSettingsAction()   
        { 
            ////Act
            IActionResult result = _settingsController.Settings();

            //Assert
            RedirectToActionResult viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("City", viewResult.ActionName);
        }

        //[Fact]
        //public void ValidModelInSettingsAction()
        //{
        //    var result = _settingsController.Settings() as ViewResult;
        //    RedirectToActionResult viewResult = Assert.IsType<RedirectToActionResult>(result);
        //    var model = viewResult;

        //    Assert.NotNull(viewResult.);
        //}


    }
}

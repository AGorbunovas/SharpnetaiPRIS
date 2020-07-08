using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using PRIS.WEB.Controllers;
using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PRIS.Test.Controller
{
    public class HomeControllerShould
    {
        private Mock<IUserStore<ApplicationUser>> _mockUserStore;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private ApplicationUser _admin;
        private HomeController _sut;

        public HomeControllerShould()
        {
            _mockUserStore = new Mock<IUserStore<ApplicationUser>>();
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(_mockUserStore.Object, null, null, null, null, null, null, null, null);

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]{new Claim(ClaimTypes.NameIdentifier, "1")}));

            _admin = new ApplicationUser();
            _mockUserManager.Setup(_ => _.GetUserAsync(claimsPrincipal)).ReturnsAsync(_admin);

            _sut = new HomeController(_mockUserManager.Object);
            _sut.ControllerContext.HttpContext = new DefaultHttpContext() { User = claimsPrincipal };

            var mockTempData = new Mock<ITempDataDictionary>();
            _sut.TempData = mockTempData.Object;
        }

        [Fact]
        public async void ReturnIndexWhenChangeInitialPasswordIsFalse()
        {
            //arrange
            _admin.ChangeInitialPassword = false;

            //act
            var result = await _sut.Index();

            // assert
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
        }

        [Fact]
        public async void ReturnIndexWithTempDataWhenChangeInitialPasswordIsTrue()
        {
            //arrange
            _admin.ChangeInitialPassword = true;

            //act
            var result = await _sut.Index();

            // assert
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("IndexWithTempData", viewResult.ViewName);
        }

    }
}

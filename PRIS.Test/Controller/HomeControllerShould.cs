using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using PRIS.WEB.Controllers;
using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using System;
using System.Security.Claims;
using System.Threading;
using Xunit;

namespace PRIS.Test.Controller
{
    public class HomeControllerShould
    {
        private HomeController _sut;
        private ApplicationDbContext _context;

        public HomeControllerShould()
        {
            //https://www.codecultivation.com/how-to-mock-asp-net-identity/
            var mockUserManager = new Mock<UserManager<ApplicationUser>>(
                                new Mock<IUserStore<ApplicationUser>>().Object,
                                new Mock<IOptions<IdentityOptions>>().Object,
                                new Mock<IPasswordHasher<ApplicationUser>>().Object,
                                new IUserValidator<ApplicationUser>[0],
                                new IPasswordValidator<ApplicationUser>[0],
                                new Mock<ILookupNormalizer>().Object,
                                new Mock<IdentityErrorDescriber>().Object,
                                new Mock<IServiceProvider>().Object,
                                new Mock<ILogger<UserManager<ApplicationUser>>>().Object);

            _sut = new HomeController(mockUserManager.Object);
            _context = InMemoryApplicationDbContext.GetInMemoryApplicationDbContext();

            var adminUser = new ApplicationUser { Email = "sdas@asda.com" };

            mockUserManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(adminUser);
        }

        [Fact]
        public async void ReturnViewForIndexAction()
        {
            // act
            IActionResult result = await _sut.Index();
        }

    }
}

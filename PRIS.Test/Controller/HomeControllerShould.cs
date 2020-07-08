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
using System.Threading.Tasks;
using Xunit;

namespace PRIS.Test.Controller
{
    public class HomeControllerShould
    {
        private HomeController _sut;
        private ApplicationDbContext _context;

        public HomeControllerShould()
        {
            ////https://www.codecultivation.com/how-to-mock-asp-net-identity/
            //var mockUserManager = new Mock<UserManager<ApplicationUser>>(
            //                    new Mock<IUserStore<ApplicationUser>>().Object,
            //                    new Mock<IOptions<IdentityOptions>>().Object,
            //                    new Mock<IPasswordHasher<ApplicationUser>>().Object,
            //                    new IUserValidator<ApplicationUser>[0],
            //                    new IPasswordValidator<ApplicationUser>[0],
            //                    new Mock<ILookupNormalizer>().Object,
            //                    new Mock<IdentityErrorDescriber>().Object,
            //                    new Mock<IServiceProvider>().Object,
            //                    new Mock<ILogger<UserManager<ApplicationUser>>>().Object);

            //_sut = new HomeController(mockUserManager.Object);
            //_context = InMemoryApplicationDbContext.GetInMemoryApplicationDbContext();

            //var adminUser = new ApplicationUser { Email = "sdas@asda.com" };

            //mockUserManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(adminUser);


            var mockUserStore = new Mock<IUserStore<ApplicationUser>>();
            var mockUserManager = new Mock<UserManager<ApplicationUser>>(mockUserStore.Object, null, null, null, null, null, null, null, null);

            var appUser = new ApplicationUser
            {
                Id = "B22698B8 - 42A2 - 4115 - 9631 - 1C2D1E2AC5F7",
                UserName = "Admin1@Admin.com",
                NormalizedUserName = "ADMIN1@ADMIN.COM",
                Email = "Admin1@Admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                PhoneNumber = "XXXXXXXXXXXXX",
                EmailConfirmed = true,
                SecurityStamp = new Guid().ToString("D"),
                ChangeInitialPassword = true
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
             {
                    new Claim(ClaimTypes.NameIdentifier, "1"),
             }));

            mockUserManager.Setup(_ => _.GetUserAsync(user)).ReturnsAsync(appUser);

            _sut = new HomeController(mockUserManager.Object);
            _sut.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };
        }

        [Fact]
        public async void ReturnViewForIndexAction()
        {
            // act
            //https://stackoverflow.com/questions/51866713/unit-testing-controller-that-uses-getuserasync-user

            //todo problem with tempData
            var result = await _sut.Index();
        }

    }
}

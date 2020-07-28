using Microsoft.AspNetCore.Mvc;
using PRIS.WEB.Controllers;
using PRIS.WEB.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PRIS.Test.Controller
{
    public class ContractControllerShould
    {
        private ApplicationDbContext _context;
        private ContractController _sut;

        public ContractControllerShould()
        {
            _context = InMemoryApplicationDbContext.GetInMemoryApplicationDbContext();
            _sut = new ContractController(_context);
        }


        [Fact]
        public void DisplayTheContractsView()
        {
            //act
            var result =_sut.Contracts(null, null);

            //assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DisplayTheContractsSignedView()
        {
            //act
            var result = _sut.ContractsSigned();

            //assert
            Assert.IsType<ViewResult>(result);
        }
    }
}

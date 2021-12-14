using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.impl;
using BLL.Services.Interface;
using Catalog.DLA.EF;
using Catalog.DLA.Repositories.Interfaces;
using Catalog.DLA.UnitOfWork;
using CCL.Security;
using CCL.Security.Identify;
using DLA.Entites;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using User = CCL.Security.Identify.User;

namespace BLL.Tests
{
    public class LokalityServiceTest
    {
        [Fact]
        public void IUnitOfWork_InputNull_ThrowArgumentNullException()
        {
            //DbContextOptions opt = new DbContextOptionsBuilder<LokalityContext>().Options;
            //IUnitOfWork nullUnitOfWork = new EFUnitOfWork(new LokalityContext(opt));
            IUnitOfWork nullUnitOfWork = null;

            Assert.Throws<ArgumentNullException>(() => new LokalityService(nullUnitOfWork));
        }

        [Fact]
        public void GetLokalitys_UserIsAdmin_ThrowMethodAccessException()
        {
            User user = new Admin(1, "test", "ABC","Test");
            //User user = new COD(1, "test", "ABC", "Test");
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            ILokalityService LokalityService = new LokalityService(mockUnitOfWork.Object);

            Assert.Throws<MethodAccessException>(() => LokalityService.GetLokality(0));
        }

        [Fact]
        public void GetLokalitys_LokalityFromDAL_CorrectMappingToLokalityDTO()
        {
            DMS user = new DMS(1, "test", "ABC", "Test");
            SecurityContext.SetUser(user);
            var LokalityService = GetLokalityService();

            var actualLokalityDto = LokalityService.GetLokality(0).First();

            Assert.True(actualLokalityDto.LocalityId == 1 && actualLokalityDto.Name == "testN" && actualLokalityDto.Population == 1);
        }


        ILokalityService GetLokalityService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedLokality = new Lokality() { LocalityId = 1, Name = "testN", Population = 1};
            var mockDbSet = new Mock<ILokalityReposotory>();
            mockDbSet.Setup(z => z.Find(
                        It.IsAny<Func<Lokality, bool>>(),
                        It.IsAny<int>(),
                        It.IsAny<int>()))
                .Returns(
                    new List<Lokality>() { expectedLokality }
                );
            mockContext
                .Setup(context =>
                    context.Lokalitys)
                .Returns(mockDbSet.Object);

            ILokalityService LokalityService = new LokalityService(mockContext.Object);

            return LokalityService;
        }
    }
}

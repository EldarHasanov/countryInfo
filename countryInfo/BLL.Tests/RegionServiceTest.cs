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
    public class RegionServiceTest
    {
        [Fact]
        public void IUnitOfWork_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            //DbContextOptions opt = new DbContextOptionsBuilder<LokalityContext>().Options;
            //IUnitOfWork nullUnitOfWork = new EFUnitOfWork(new LokalityContext(opt));
            IUnitOfWork nullUnitOfWork = null;
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new RegionService(nullUnitOfWork));
        }

        [Fact]
        public void GetRegions_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "test", "ABC","Test");
            //User user = new COD(1, "test", "ABC", "Test");
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IRegionService RegionService = new RegionService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => RegionService.GetRegions(0));
        }

        [Fact]
        public void GetRegions_RegionFromDAL_CorrectMappingToRegionDTO()
        {
            // Arrange
            DMS user = new DMS(1, "test", "ABC", "Test");
            SecurityContext.SetUser(user);
            var RegionService = GetRegionService();

            // Act
            var actualRegionDto = RegionService.GetRegions(0).First();

            // Assert
            Assert.True(actualRegionDto.RegionId == 1 && actualRegionDto.Name == "testN" && actualRegionDto.Population == 1);
        }


        IRegionService GetRegionService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedRegion = new Region() { RegionId = 1, Name = "testN", Population = 1};
            var mockDbSet = new Mock<IRegionRepository>();
            mockDbSet.Setup(z => z.Find(
                        It.IsAny<Func<Region, bool>>(),
                        It.IsAny<int>(),
                        It.IsAny<int>()))
                .Returns(
                    new List<Region>() { expectedRegion }
                );
            mockContext
                .Setup(context =>
                    context.Regions)
                .Returns(mockDbSet.Object);

            IRegionService RegionService = new RegionService(mockContext.Object);

            return RegionService;
        }
    }
}

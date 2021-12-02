using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.DLA.EF;
using DLA.Entites;
using DLA.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;

namespace DLA.Tests
{

    class TestLocalityRepository
        : BaseRepository<Lokality>
    {
        public TestLocalityRepository(DbContext context)
            : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputStreetInstance_CalledAddMethodOfDBSetWithStreetInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<LokalityContext>().Options;
            var mockContext = new Mock<LokalityContext>(opt);
            var mockDbSet = new Mock<DbSet<Lokality>>();
            mockContext.Setup(context => context.Set<Lokality>()).Returns(mockDbSet.Object);
            var repository = new TestLocalityRepository(mockContext.Object);

            Lokality expectedStreet = new Mock<Lokality>().Object;

            //Act
            repository.Create(expectedStreet);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Add(expectedStreet), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<LokalityContext>().Options;
            var mockContext = new Mock<LokalityContext>(opt);
            var mockDbSet = new Mock<DbSet<Lokality>>();
            mockContext.Setup(context => context.Set<Lokality>()).Returns(mockDbSet.Object);
            var repository = new TestLocalityRepository(mockContext.Object);

            Lokality expectedStreet = new Lokality() { LokalityId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.LokalityId)).Returns(expectedStreet);

            //Act
            repository.Delete(expectedStreet.LokalityId);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedStreet.LokalityId), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(expectedStreet), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<LokalityContext>()
                .Options;
            var mockContext = new Mock<LokalityContext>(opt);
            var mockDbSet = new Mock<DbSet<Lokality>>();
            mockContext.Setup(context => context.Set<Lokality>()).Returns(mockDbSet.Object);

            Lokality expectedStreet = new Lokality() { LokalityId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.LokalityId)).Returns(expectedStreet);
            var repository = new TestLocalityRepository(mockContext.Object);

            //Act
            var actualStreet = repository.Get(expectedStreet.LokalityId);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedStreet.LokalityId), Times.Once());
            Assert.Equal(expectedStreet, actualStreet);
        }
    }
}

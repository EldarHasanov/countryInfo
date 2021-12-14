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
        public void Create_InputLokalityInstance_CalledAddMethodOfDBSetWithLokalityInstance()
        {

            using (LokalityContext db = new LokalityContext())
            {
                //User user1 = new User { Name = "Tom", Age = 33 };
                //User user2 = new User { Name = "Alice", Age = 26 };


                //Lokality Lok = new Lokality {LocalityId = 4, Name = "Chernihiv", Population = 1985};

                //db.Localities.

                db.Regions.AddRange(
                    new Region
                    {
                        //RegionId = 4,
                        Name = "Chernihiv",
                        Population = 1985
                    });

                db.SaveChanges();
            }
            /*DbContextOptions opt = new DbContextOptionsBuilder<LokalityContext>().Options;
            var mockContext = new Mock<LokalityContext>(opt);
            var mockDbSet = new Mock<DbSet<Lokality>>();
            mockContext.Setup(context => context.Set<Lokality>()).Returns(mockDbSet.Object);
            var repository = new TestLocalityRepository(mockContext.Object);

            Lokality expectedLokality = new Mock<Lokality>().Object;

            repository.Create(expectedLokality);

            mockDbSet.Verify(dbSet => dbSet.Add(expectedLokality), Times.Once());*/
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<LokalityContext>().Options;
            var mockContext = new Mock<LokalityContext>(opt);
            var mockDbSet = new Mock<DbSet<Lokality>>();
            mockContext.Setup(context => context.Set<Lokality>()).Returns(mockDbSet.Object);
            var repository = new TestLocalityRepository(mockContext.Object);

            Lokality expectedLokality = new Lokality() { LocalityId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedLokality.LocalityId)).Returns(expectedLokality);

            repository.Delete(expectedLokality.LocalityId);

            mockDbSet.Verify(dbSet => dbSet.Find(expectedLokality.LocalityId), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(expectedLokality), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<LokalityContext>()
                .Options;
            var mockContext = new Mock<LokalityContext>(opt);
            var mockDbSet = new Mock<DbSet<Lokality>>();
            mockContext.Setup(context => context.Set<Lokality>()).Returns(mockDbSet.Object);

            Lokality expectedLokality = new Lokality() { LocalityId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedLokality.LocalityId)).Returns(expectedLokality);
            var repository = new TestLocalityRepository(mockContext.Object);

            var actualLokality = repository.Get(expectedLokality.LocalityId);

            mockDbSet.Verify(dbSet => dbSet.Find(expectedLokality.LocalityId), Times.Once());
            Assert.Equal(expectedLokality, actualLokality);
        }
    }
}

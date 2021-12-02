using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLA.Entites;
using DLA.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

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
}

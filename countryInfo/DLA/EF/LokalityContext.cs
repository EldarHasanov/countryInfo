using DLA.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DLA.EF
{
    public class LokalityContext
        : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Lokality> Lokalities { get; set; }
        public DbSet<District> Districts { get; set; }

        public LokalityContext(DbContextOptions options)
            : base(options)
        {
        }

    }
}
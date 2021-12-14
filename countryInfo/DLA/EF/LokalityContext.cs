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
        //public DbSet<Lokality> Localities { get; set; }
        public DbSet<Lokality> Localities { get; set; }
        public DbSet<District> Districts { get; set; }

        public LokalityContext()
            //: base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;database=country_info;password=1111;uid=admin;";
            
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 24)));
        }
    }
}
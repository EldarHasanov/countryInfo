//using Catalog.DLA.Entites;
//using Catalog.DAL.Repositories.Impl;
//using Catalog.DAL.Repositories.Interfaces;
//using Catalog.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using Catalog.DLA.Repositories.Impl;
using Catalog.DLA.Repositories.Interfaces;
using Catalog.DLA.UnitOfWork;

namespace Catalog.DLA.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private LokalityContext db;
        private UserRepository userRepository;
        private RegionRepository regionRepository;
        private LokalityRepository lokalityRepository;
        private DistrictRepository districtRepository;

        public EFUnitOfWork(LokalityContext context)
        {
            db = context;
        }
        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(db);
                }

                return userRepository;
            }
        }


        public IDistrictRepository Districs
        {
            get
            {
                if (districtRepository == null)
                {
                    districtRepository = new DistrictRepository(db);
                }

                return districtRepository;
            }
        }

        public IRegionRepository Regions
        {
            get
            {
                if (regionRepository == null)
                {
                    regionRepository = new RegionRepository(db);
                }

                return regionRepository;
            }
        }
        public ILokalityReposotory Lokalitys
        {
            get
            {
                if (lokalityRepository == null)
                {
                    lokalityRepository = new LokalityRepository(db);
                }

                return lokalityRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
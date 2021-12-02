using System;
using System.Collections.Generic;
using System.Text;
using Catalog.DLA.Repositories.Interfaces;

namespace Catalog.DLA.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ILokalityReposotory Lokalitys { get; }
        IDistrictRepository Districs { get; }
        IRegionRepository Regions { get; }
        void Save();
    }
}
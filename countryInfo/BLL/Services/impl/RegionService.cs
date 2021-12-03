using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interface;
using Catalog.DLA.UnitOfWork;
using CCL.Security;
using CCL.Security.Identify;
using DLA.Entites;
using Catalog.DLA.Repositories.Interfaces;


namespace BLL.Services.impl
{
    public class RegionService : IRegionService

    {
    private readonly IUnitOfWork _database;
    private int pageSize = 10;

    public RegionService(
        IUnitOfWork unitOfWork)
    {
        if (unitOfWork == null)
        {
            throw new ArgumentNullException(nameof(unitOfWork));
        }

        _database = unitOfWork;
    }

    /// <exception cref="MethodAccessException"></exception>
    public IEnumerable<RegionDTO> GetRegions(int pageNumber)
    {
        var user = SecurityContext.GetUser();
        var userType = user.GetType();
        if (userType != typeof(COD) && userType != typeof(DMS) && userType != typeof(DABI))
        {
            throw new MethodAccessException();
        }
        var regionId = 1;
        var RegionEntities = _database.Regions.Find(z => z.RegionId == regionId, pageNumber, pageSize);
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Region, RegionDTO>()).CreateMapper();
        var streetsDto = mapper.Map<IEnumerable<Region>, List<RegionDTO>>(RegionEntities);
        return streetsDto;
    }
    }
}

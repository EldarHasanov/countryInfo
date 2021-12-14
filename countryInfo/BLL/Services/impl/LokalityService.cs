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
    public class LokalityService : ILokalityService

    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public LokalityService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<LokalityDTO> GetLokality(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(COD) && userType != typeof(DMS) && userType != typeof(DABI))
            {
                throw new MethodAccessException();
            }
            var LokalityId = 1;
            var LokalityEntities = _database.Lokalitys.Find(z => z.LocalityId == LokalityId, pageNumber, pageSize);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Lokality, LokalityDTO>()).CreateMapper();
            var streetsDto = mapper.Map<IEnumerable<Lokality>, List<LokalityDTO>>(LokalityEntities);
            return streetsDto;
        }
    }
}
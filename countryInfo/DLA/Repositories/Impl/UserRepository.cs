using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Catalog.DLA.EF;
using Catalog.DLA.Repositories.Interfaces;
using DLA.Entites;
using DLA.Repositories.Impl;

namespace Catalog.DLA.Repositories.Impl
{
    public class UserRepository
        : BaseRepository<User>, IUserRepository
    {

        internal UserRepository(LokalityContext context)
            : base(context)
        {
        }
    }
}
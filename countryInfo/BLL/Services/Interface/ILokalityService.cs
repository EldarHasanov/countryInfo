using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.DTO;

namespace BLL.Services.Interface
{
    public interface ILokalityService
    {
        IEnumerable<LokalityDTO> GetLokality(int page);
    }
}

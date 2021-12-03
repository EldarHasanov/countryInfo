using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RegionDTO
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public uint Population { get; set; }
        //public IEnumerable<Lokality> Lokalities { get; set; }
    }
}

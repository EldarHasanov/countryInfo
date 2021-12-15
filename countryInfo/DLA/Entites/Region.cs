using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA.Entites
{
    public class Region
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public uint Population { get; set; }
        public List<Lokality> Loсalities { get; set; }
    }
}

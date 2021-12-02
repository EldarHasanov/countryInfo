using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA.Entites
{
    public class Lokality
    {
        public int LokalityId { get; set; }
        public string Name { get; set; }
        public uint population { get; set; }
        public IEnumerable<District> Districts { get; set; }
    }
}

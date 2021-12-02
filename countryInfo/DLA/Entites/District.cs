using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DLA.Entites
{
    public class District
    {
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public uint Population { get; set; }
        
    }
}

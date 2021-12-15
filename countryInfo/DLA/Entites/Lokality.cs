using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA.Entites
{
    public class Lokality
    {
        [Key]
        public int LocalityId { get; set; }
        public string Name { get; set; }
        public uint Population { get; set; }
        public List<District> Districts { get; set; }
    }
}

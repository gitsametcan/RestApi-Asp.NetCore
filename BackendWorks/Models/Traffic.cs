using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace BackendWorks.Models
{

    public class Traffic
    {
        
        public int PolicyId { get; set; }
        public string PlakaIlKodu { get; set; }
        public string PlakaKodu { get; set; }

        [Key]
        public int TrafficId { get; set; }

    }

    
}

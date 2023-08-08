using Microsoft.EntityFrameworkCore;

namespace BackendWorks.NonTable
{
    [Keyless]
    public class TrafficPolicy
    {
        public int PolicyId { get; set; }
        public string PlakaIlKodu { get; set; }
        public string PlakaKodu { get; set; }
    }
}

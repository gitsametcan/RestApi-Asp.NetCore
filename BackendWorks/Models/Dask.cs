using System.ComponentModel.DataAnnotations;

namespace BackendWorks.Models
{
    public class Dask 
    {
        public int PolicyId { get; set; }
        public string Adres { get; set; }
        public string Ilce { get; set; }
        public string Il { get; set; }
        
        [Key]
        public int DaskId { get; set; }

    }
}

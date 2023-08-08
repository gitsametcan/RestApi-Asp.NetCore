using BackendWorks.NonTable;

namespace BackendWorks.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public int CustomerTC { get; set; }
        public DateTime TanzimTarihi { get; set; }
        public DateTime VadeBaslangic { get; set; }

        public DateTime? VadeBitis { get; set; }
        public int Prim { get; set; }
        public string ProductType { get; set; }
    }
}

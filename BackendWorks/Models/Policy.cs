using BackendWorks.NonTable;

namespace BackendWorks.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public DateTime TanzimTarihi { get; set; }
        public DateTime VadeBaslangic { get; set; }
        public DateTime? VadeBitis { get; set; }
        public double Prim { get; set; }
        public PolicyType policyType { get; set; }
    }
}

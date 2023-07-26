using Microsoft.EntityFrameworkCore;

namespace BackendWorks.Models
{
    public class Customer
    {
        public int TCKN { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}

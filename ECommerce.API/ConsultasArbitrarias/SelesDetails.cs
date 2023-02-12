using Microsoft.EntityFrameworkCore.Metadata;

namespace ECommerce.API.ConsultasArbitrarias
{
    public class SelesDetails
    {
        public Guid NumFact { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string RNC { get; set; }
        public string telephone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public int Cuantity { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}

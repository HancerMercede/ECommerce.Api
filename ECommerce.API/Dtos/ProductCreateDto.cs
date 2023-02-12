

namespace ECommerce.API.Dtos;

public class ProductCreateDto
{
    public string? Description { get; set; }

    public double Price { get; set; }

    public int Cuantity { get; set; }

    public int FactorId { get; set; }
    public int FruitId { get; set; }
}

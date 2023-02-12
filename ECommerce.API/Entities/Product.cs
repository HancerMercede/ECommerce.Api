namespace ECommerce.API.Entities;

public class Product
{
    public Product()
    {
        Factor = new();
    }
    public Guid Id { get; set; } 
    public string ? Description { get; set; }
    public double Price { get; set; }
    public int Cuantity { get; set; }
    public int FruitId { get; set; }
    public int FactorId { get; set; }
    public virtual Factor Factor { get; set; }
}

namespace ECommerce.API.Dtos;

public class InvoiceDetailCreateDto
{
    public string ProductId { get; set; }
    public int Cuantity { get; set; }
    public decimal Price { get; set; }
    public decimal Iva { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
}

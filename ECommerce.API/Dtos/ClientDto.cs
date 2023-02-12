namespace ECommerce.API.Dtos;

public class ClientDto
{
    public string? ClientId { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string? Telephone { get; set; }
    [EmailAddress(ErrorMessage = "Please select a valid Email.")]
    public string? Email { get; set; }
    public string? RNC { get; set; }
    public string? DNI { get; set; }
}

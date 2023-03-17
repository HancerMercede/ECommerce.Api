namespace ECommerce.API.Dtos;

public class NCFDetailDto
{
    public string NCF_Serie { get; set; }
    public string NCF_Type { get; set; }
    public string Secuence { get; set; }
    public string Active { get; set; }

    [NotMapped]
    public string NCFSecuence => string.Concat(NCF_Serie, NCF_Type, Secuence);
}

namespace ECommerce.API.Dtos;

public class NCFDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public IEnumerable<NCFDetailDto> NCF_Infos { get; set; }
}

namespace ECommerce.API.Entities;

public class NCF_Info
{
    public string NCF_Serie { get; set; }
    public string   NCF_Type { get; set; }
    public string Secuence { get; set; }
    public string Active { get; set; }
    public virtual NCF NCF { get; set; }
}

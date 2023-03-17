namespace ECommerce.API.Entities;

public class NCF
{
    public NCF()
    {
        NCF_Infos = new HashSet<NCF_Info>();
    }
    public int Id { get; set; }
    public string Description { get; set; }
    public virtual ICollection<NCF_Info> NCF_Infos { get; set; }
}

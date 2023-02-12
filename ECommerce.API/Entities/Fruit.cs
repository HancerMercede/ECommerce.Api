using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Entities
{
    public class Fruit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string? Name { get; set; }
    }
}

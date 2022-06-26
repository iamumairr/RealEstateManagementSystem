using System.ComponentModel.DataAnnotations;

namespace RealEstateManagementSystem.Models
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        public string? Name { get; set; }

        public ICollection<Home>? Homes { get; set; }
    }
}

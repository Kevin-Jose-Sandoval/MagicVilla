using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class VillaUpdateDto
    {
        [Required]
        public int Id{ get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Detail { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int SquareMeter { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}

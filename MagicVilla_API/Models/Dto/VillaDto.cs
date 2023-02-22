using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class VillaDto
    {
        public int Id{ get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int SquareMeter { get; set; }
    }
}

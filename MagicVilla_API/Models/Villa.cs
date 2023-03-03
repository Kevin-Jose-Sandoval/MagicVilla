using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_API.Models
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        [Required]
        public double Cost{ get; set; }
        public int Capacity { get; set; }
        public int SquareMeter { get; set; }
        public string ImageUrl{ get; set; }
        public string Amenity { get; set; }
        public DateTime CreatedDate{ get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}

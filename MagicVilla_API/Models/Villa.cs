using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models
{
    public class Villa
    {
        [Key]
        public int IdVilla { get; set; }
        public string Name { get; set; } = null!;
        public string Details { get; set; } = null!;
        [Required]
        public double Price { get; set; }
        public int Capacity { get; set; }
        public double Dimensions { get; set; } 
        public string ImageUrl { get; set; } = null!;
        public string Amenity { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime UpdateTime { get; set;}

    }

}

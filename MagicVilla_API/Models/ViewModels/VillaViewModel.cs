using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.ViewModels
{
    public class VillaViewModel
    {
        public int IdVilla { get; set; }
        public string Name { get; set; } = null!;
        public string Details { get; set; } = null!;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Amenity { get; set; } = null!;
       
    }
}

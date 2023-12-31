﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class VillaDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Details { get; set; } = null!;
        [Required]
        public double Price { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public double Dimensions { get; set; }
        [Required]
        public string ImageUrl { get; set; } = null!;
        [Required]
        public string Amenity { get; set; } = null!;
       
    }
}

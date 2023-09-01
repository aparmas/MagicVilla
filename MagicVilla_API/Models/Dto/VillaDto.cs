﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class VillaDto
    {
        public int IdVilla { get; set; }
        public string Name { get; set; } = null!;
        public string Details { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public double Dimensions { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Amenity { get; set; } = null!;
       
    }
}
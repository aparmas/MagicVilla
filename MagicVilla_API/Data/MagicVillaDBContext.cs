using MagicVilla_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Data
{
    public class MagicVillaDBContext : DbContext
    {
        public MagicVillaDBContext(DbContextOptions<MagicVillaDBContext> dbContextOptions)
            :base(dbContextOptions)
        {
                
        }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    IdVilla = 1,
                    Name = "Villa Bayamo",
                    Details = "All details",
                    Price = 85.5,
                    Capacity = 100,
                    Dimensions = 100,
                    ImageUrl = "",
                    Amenity = "",
                    CreationDate = DateTime.Now,
                    UpdateTime = DateTime.Now,





                }
                );

                /* public int IdVilla { get; set; }
        public string Name { get; set; } = null!;
        public string Details { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public double Dimensions { get; set; } 
        public string ImageUrl { get; set; } = null!;
        public string Amenity { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime UpdateTime { get; set;}*/
        }
    }
}

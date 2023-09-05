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
                         
        }
    }
}

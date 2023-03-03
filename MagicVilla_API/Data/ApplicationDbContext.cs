using MagicVilla_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Villa> Villas { get; set; }

        // initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id= 1,
                    Name= "Villa Real",
                    Detail= "Detalle de la Villa...",
                    ImageUrl= "",
                    Capacity= 5,
                    SquareMeter= 50,
                    Cost= 200,
                    Amenity= "",
                    CreatedDate= DateTime.Now,
                    UpdatedDate= DateTime.Now,
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Premium Vista a la Piscina",
                    Detail = "Detalle de la Villa...",
                    ImageUrl = "",
                    Capacity = 4,
                    SquareMeter = 40,
                    Cost = 150,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            );
        }
    }
}
